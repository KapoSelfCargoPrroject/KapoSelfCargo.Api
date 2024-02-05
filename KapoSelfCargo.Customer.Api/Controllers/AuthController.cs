using KapoSelfCargo.Customer.Api.Infrastructure.Dto;
using KapoSelfCargo.Customer.Api.Services.Authentication;
using KapoSelfCargo.Customer.Api.Shared.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KapoSelfCargo.Customer.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthenticationService _authenticationService;

		public AuthController(IAuthenticationService authenticationService)
		{
			_authenticationService = authenticationService;
		}
		[HttpPost]
		[Route("register")]
		public async Task<Response> Register([FromBody] RegisterRequestDto request)
		{
			return await _authenticationService.RegisterAsync(request);
		}
		[HttpPost]
		[Route("login")]
		public async Task<Response<string>> Login([FromBody] LoginRequestDto request)
		{
			return await _authenticationService.LoginAsync(request);
		}
	}
}
