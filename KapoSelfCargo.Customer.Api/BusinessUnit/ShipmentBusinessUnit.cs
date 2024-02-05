using KapoSelfCargo.Customer.Api.DataAccess;
using KapoSelfCargo.Customer.Api.Infrastructure.Dto;
using KapoSelfCargo.Customer.Api.Infrastructure.Model;
using KapoSelfCargo.Customer.Api.Infrastructure.Utility;
using KapoSelfCargo.Customer.Api.Shared.ComplexTypes;
using KapoSelfCargo.Customer.Api.Shared.Concrete;

namespace KapoSelfCargo.Customer.Api.BusinessUnit
{
	public interface IShipmentBusinessUnit
	{
		Task<Response<IList<ShipmentListDto>>> GetShipmentByUserFirebaseId();
		Task<Response<IList<ShipmentListDto>>> SearchShipmentByUserFirebaseId(string trackingNumber);
		Task<Response> TAddAsync(Shipment shipment);
	}
	public class ShipmentBusinessUnit : IShipmentBusinessUnit
	{
		private readonly IShipmentDataAccess _shipmentDataAccess;
		private readonly IUserUtility _userUtility;
		public ShipmentBusinessUnit(IShipmentDataAccess shipmentDataAccess, IUserUtility userUtility)
		{
			_shipmentDataAccess = shipmentDataAccess;
			_userUtility = userUtility;
		}

		public async Task<Response<IList<ShipmentListDto>>> GetShipmentByUserFirebaseId()
		{
			try
			{
				var userFirebaseId = _userUtility.GetFirebaseUserId();
				if (userFirebaseId == null)
				{
					return new Response<IList<ShipmentListDto>>(ResponseCode.BadRequest, "Invalid user. Firebase ID is missing.");
				}
				var shipmentEntity = await _shipmentDataAccess.GetShipmentByUserFirebaseId(userFirebaseId);
				if (shipmentEntity.Any())
				{
					return new Response<IList<ShipmentListDto>>(ResponseCode.Success, "Shipments retrieved successfully.");
				}
				return new Response<IList<ShipmentListDto>>(ResponseCode.NotFound, "No shipments found for the user.");
			}
			catch
			{
				return new Response<IList<ShipmentListDto>>(ResponseCode.NotFound, "No shipments found for the user.");
			}
		}

		public async Task<Response<IList<ShipmentListDto>>> SearchShipmentByUserFirebaseId(string trackingNumber)
		{
			try
			{
				var userFirebaseId = _userUtility.GetFirebaseUserId();
				if (userFirebaseId == null)
				{
					return new Response<IList<ShipmentListDto>>(ResponseCode.BadRequest, "Invalid user. Firebase ID is missing.");
				}
				if (trackingNumber == null)
				{
					return new Response<IList<ShipmentListDto>>(ResponseCode.BadRequest, "Invalid tracking number. Please provide a valid tracking number.");
				}
				var shipmentEntity = await _shipmentDataAccess.SearchShipmentByUserFirebaseId(userFirebaseId, trackingNumber);
				if (shipmentEntity.Any())
				{
					return new Response<IList<ShipmentListDto>>(ResponseCode.Success, "Shipments retrieved successfully.");
				}
				return new Response<IList<ShipmentListDto>>(ResponseCode.NotFound, "No shipments found for the user with the specified tracking number.");
			}
			catch
			{
				return new Response<IList<ShipmentListDto>>(ResponseCode.NotFound, "An unexpected error occurred while processing the request.");
			}
		}

		public async Task<Response> TAddAsync(Shipment shipment)
		{
			try
			{
				if (shipment == null)
				{
					return new Response(ResponseCode.BadRequest, "Invalid shipment. Shipment object is null.");
				}
				var saveChangesValue = await _shipmentDataAccess.AddAsync(shipment);
				if (saveChangesValue > 0)
				{
					return new Response(ResponseCode.Success, "Shipment added successfully.");
				}
				return new Response(ResponseCode.BadRequest, "Failed to add shipment. Please try again.");
			}
			catch
			{
				return new Response(ResponseCode.InternalServerError, "An unexpected error occurred while processing the request.");
			}
		}
	}
}
