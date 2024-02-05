using FirebaseAdmin.Auth;
using KapoSelfCargo.Customer.Api.BusinessUnit;
using KapoSelfCargo.Customer.Api.Infrastructure.Dto;
using KapoSelfCargo.Customer.Api.Infrastructure.Model;
using KapoSelfCargo.Customer.Api.Infrastructure.Utility;
using KapoSelfCargo.Customer.Api.Shared.ComplexTypes;
using KapoSelfCargo.Customer.Api.Shared.Concrete;
using Microsoft.IdentityModel.Tokens;

namespace KapoSelfCargo.Customer.Api.Services.Authentication
{
	public class AuthenticationService : IAuthenticationService
	{
		private readonly HttpClient _httpClient;
		private readonly IUserBusinessUnit _userBusinessUnit;
		private readonly IUserUtility _userUtility;

		public AuthenticationService(HttpClient httpClient, IUserBusinessUnit userBusinessUnit, IUserUtility userUtility)
		{
			_httpClient = httpClient;
			_userBusinessUnit = userBusinessUnit;
			_userUtility = userUtility;
		}
		public async Task<Response<string>> LoginAsync(LoginRequestDto request)
		{
			var credentials = new
			{
				request.Email,
				request.Password,
				returnSecureToken = true
			};
			var response = await _httpClient.PostAsJsonAsync("", credentials);
			if (!response.IsSuccessStatusCode)
			{
				return new Response<string>(ResponseCode.InternalServerError, "User login failed");
			}
			var authFirebaseObject = await response.Content.ReadFromJsonAsync<AuthFirebase>();
			if(authFirebaseObject == null) {
				return new Response<string>(ResponseCode.InternalServerError, "User login failed");
			}
			return new Response<string>(ResponseCode.Success, "User login successfully", authFirebaseObject!.IdToken!);
		}
		public async Task<Response> RegisterAsync(RegisterRequestDto request)
		{
			var userArgs = new UserRecordArgs
			{
				Email = request.Email,
				Password = request.Password
			};
			var usuario = await FirebaseAuth.DefaultInstance.CreateUserAsync(userArgs);
			var user = await _userBusinessUnit.TAddAsync(new User
			{
				Email = usuario.Email,
				FirebaseId = usuario.Uid
			});
			if(user.ResponseCode == ResponseCode.Success)
			{
				return new Response(ResponseCode.Success, "User added successfully");
			}
			return new Response(ResponseCode.BadRequest, "User not added");
		}
	}
}
