using KapoSelfCargo.Customer.Api.BusinessUnit;
using KapoSelfCargo.Customer.Api.Infrastructure.Dto;
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
	public class ShipmentController : ControllerBase
	{
		private readonly IShipmentBusinessUnit _shipmentBusinessUnit;
		public ShipmentController(IShipmentBusinessUnit shipmentBusinessUnit)
		{
			_shipmentBusinessUnit = shipmentBusinessUnit;
		}
		[HttpGet]
		[Route(" GetShipment")]
		public async Task<Response<IList<ShipmentListDto>>> GetShipmentByUserFirebaseId()
		{
			return await  _shipmentBusinessUnit.GetShipmentByUserFirebaseId();
		}
		[HttpGet]
		[Route("SearchShipment")]
		public async Task<Response<IList<ShipmentListDto>>> SearchShipmentByUserFirebaseId([FromBody] string trackingNumber)
		{
			return await _shipmentBusinessUnit.SearchShipmentByUserFirebaseId(trackingNumber);
		}
		[HttpPost]
		[Route("AddShipment")]
		public async Task<Response> AddAsync ([FromBody] Shipment shipment)
		{
			return await _shipmentBusinessUnit.TAddAsync(shipment);
		}
	}
}
