using System.ComponentModel.DataAnnotations;

namespace KapoSelfCargo.Customer.Api.Infrastructure.Model
{
	public class Shipment
	{
		[Key]
		public int Id { get; set; }
		public string? FirebaseId {  get; set; }
		public string? TrackingNumber { get; set; }
		public string? Sender {  get; set; }
		public string? Recipient { get; set; }	
		public string? ShippingCompany { get; set; }
		public string? ShipmentStatus { get; set; }
		public string? ShipmentDate { get; set; }
		public string? EstimatedDeliveryDate { get; set; }
		public string? DeliveryDate { get; set; }
		public string? TotalCost { get; set; }
	}
}
