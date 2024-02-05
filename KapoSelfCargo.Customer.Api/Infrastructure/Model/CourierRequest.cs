using System.ComponentModel.DataAnnotations;

namespace KapoSelfCargo.Customer.Api.Infrastructure.Model
{
	public class CourierRequest
	{
		[Key]
		public int Id { get; set; }
		public string? RequestNumber { get; set; }
		public string? Sender { get; set; }
		public string? Recipient { get; set; }
		public string? ShipmentType { get; set; }
		public string? Weight { get; set; }
		public string? ShipmentDate { get; set; }
		public string? DeliveryAddress { get; set; }
		public string? DeliveryUrgency { get; set; }
		public string? Status { get; set; }
	}
}
