using KapoSelfCargo.Customer.Api.Infrastructure;
using KapoSelfCargo.Customer.Api.Infrastructure.Dto;
using KapoSelfCargo.Customer.Api.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace KapoSelfCargo.Customer.Api.DataAccess
{
	public interface IShipmentDataAccess
	{
		Task<int> AddAsync(Shipment shipment);
		Task<IList<ShipmentListDto>> GetShipmentByUserFirebaseId(string userFirebaseId);
		Task<IList<ShipmentListDto>> SearchShipmentByUserFirebaseId(string userFirebaseId, string trackingNumber);
	}
	public class ShipmentDataAccess : IShipmentDataAccess
	{
		private readonly KapoSelfCargoContext _context;
		public ShipmentDataAccess(KapoSelfCargoContext context)
		{
			_context = context;
		}

		public async Task<int> AddAsync(Shipment shipment)
		{
			_context.Shipments.Add(shipment);
			return await _context.SaveChangesAsync();
		}

		public async Task<IList<ShipmentListDto>> GetShipmentByUserFirebaseId(string userFirebaseId)
		{
			return await _context.Shipments.Where(x=> x.FirebaseId == userFirebaseId)
				.OrderByDescending(x=> x.Id).Select(x=> new ShipmentListDto
			{
				DeliveryDate = x.DeliveryDate,
				EstimatedDeliveryDate = x.EstimatedDeliveryDate,
				Recipient = x.Recipient,
				Sender = x.Sender,
				ShipmentDate = x.ShipmentDate,
				ShipmentStatus = x.ShipmentStatus,
				ShippingCompany = x.ShippingCompany,
				TotalCost = x.TotalCost,
				TrackingNumber = x.TrackingNumber
			}).ToListAsync();
		}

		public async Task<IList<ShipmentListDto>> SearchShipmentByUserFirebaseId(string userFirebaseId, string trackingNumber)
		{
			return await _context.Shipments.Where(x => x.FirebaseId == userFirebaseId && x.TrackingNumber == trackingNumber)
				.OrderByDescending(x => x.Id).Select(x => new ShipmentListDto
				{
					DeliveryDate = x.DeliveryDate,
					EstimatedDeliveryDate = x.EstimatedDeliveryDate,
					Recipient = x.Recipient,
					Sender = x.Sender,
					ShipmentDate = x.ShipmentDate,
					ShipmentStatus = x.ShipmentStatus,
					ShippingCompany = x.ShippingCompany,
					TotalCost = x.TotalCost,
					TrackingNumber = x.TrackingNumber
				}).ToListAsync();
		}
	}
}
