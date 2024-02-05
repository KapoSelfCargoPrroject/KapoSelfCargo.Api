namespace KapoSelfCargo.Customer.Api.Infrastructure.Dto
{
	public class ShipmentListDto
	{
		public string? TrackingNumber { get; set; }
		public string? Sender { get; set; }
		public string? Recipient { get; set; }
		public string? ShippingCompany { get; set; }
		public string? ShipmentStatus { get; set; }
		public string? ShipmentDate { get; set; }
		public string? EstimatedDeliveryDate { get; set; }
		public string? DeliveryDate { get; set; }
		public string? TotalCost { get; set; }
	}
}
