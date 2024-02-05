using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using KapoSelfCargo.Customer.Api.BusinessUnit;
using KapoSelfCargo.Customer.Api.DataAccess;
using KapoSelfCargo.Customer.Api.Infrastructure;
using KapoSelfCargo.Customer.Api.Infrastructure.Utility;
using KapoSelfCargo.Customer.Api.Services.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<KapoSelfCargoContext>();
builder.Services.AddTransient<ICourierRequestBusinessUnit, CourierRequestBusinessUnit>();
builder.Services.AddTransient<ICourierRequestDataAccess, CourierRequestDataAccess>();
builder.Services.AddTransient<IShipmentBusinessUnit, ShipmentBusinessUnit>();
builder.Services.AddTransient<IShipmentDataAccess, ShipmentDataAccess>();
builder.Services.AddTransient<IUserBusinessUnit, UserBusinessUnit>();
builder.Services.AddTransient<IUserDataAccess, UserDataAccess>();
builder.Services.AddTransient<IUserUtility, UserUtility>();
builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		options.Authority = builder.Configuration["Authentication:ValidIssuer"];
		options.Audience = builder.Configuration["Authentication:Audience"];
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidIssuer = builder.Configuration["Authentication:ValidIssuer"],
			ValidateAudience = true,
			ValidAudience = builder.Configuration["Authentication:ValidAudience"],
			ValidateIssuerSigningKey = true,
			ValidateLifetime = true,
		};
	});

FirebaseApp.Create(new AppOptions()
{
	Credential = GoogleCredential.FromFile("firebase.json")
});
builder.Services.AddHttpClient<IAuthenticationService, AuthenticationService>((sp, httpClient) =>
{
	var configuration = sp.GetRequiredService<IConfiguration>();
	httpClient.BaseAddress = new Uri(configuration["Authentication:TokenUri"]);
});
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll", builder =>
	{
		builder.AllowAnyOrigin()
			.AllowAnyMethod()
			.AllowAnyHeader();
	});
});
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	try
	{
		var context = services.GetRequiredService<KapoSelfCargoContext>();
		SampleDataSeeder.Seed(context);
	}
	catch (Exception ex)
	{
		var logger = services.GetRequiredService<ILogger<Program>>();
		logger.LogError(ex, "An error occurred while seeding the database.");
	}
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//	app.UseSwagger();
//	app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Health Track Customer API v1"));
//}
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Health Track Customer API v1"));

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
