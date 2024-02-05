using KapoSelfCargo.Customer.Api.BusinessUnit;
using KapoSelfCargo.Customer.Api.Infrastructure.Model;
using KapoSelfCargo.Customer.Api.Shared.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KapoSelfCargo.Customer.Api.Controllers
{
	[Route("api/[controller]")]
	[Authorize]
	[ApiController]
	public class CourierRequestController : ControllerBase
	{
		private readonly ICourierRequestBusinessUnit _courierRequestBusinessUnit;
		public CourierRequestController(ICourierRequestBusinessUnit courierRequestBusinessUnit)
		{
			_courierRequestBusinessUnit = courierRequestBusinessUnit;
		}
		[HttpPost]
		[Route("AddCourierRequest")]
		public async Task<Response> AddAsync([FromBody] CourierRequest courierRequest)
		{
			return await _courierRequestBusinessUnit.TAddAsync(courierRequest);
		}
	}
}
