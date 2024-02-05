using KapoSelfCargo.Customer.Api.Infrastructure.Dto;
using KapoSelfCargo.Customer.Api.Shared.Concrete;

namespace KapoSelfCargo.Customer.Api.Services.Authentication
{
	public interface IAuthenticationService
	{
		Task<Response> RegisterAsync(RegisterRequestDto request);
		Task<Response<string>> LoginAsync(LoginRequestDto request);
	}
}
