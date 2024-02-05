using KapoSelfCargo.Customer.Api.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace KapoSelfCargo.Customer.Api.Infrastructure
{
	public class KapoSelfCargoContext: DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"workstation id=kaposelfcargo.mssql.somee.com;user id=kaposelfcargo_SQLLogin_1;pwd=je29v9xvc3;data source=kaposelfcargo.mssql.somee.com;initial catalog=kaposelfcargo; Trust Server Certificate=true;");

		}
		public DbSet<User> Users { get; set; }
		public DbSet<Shipment> Shipments { get; set; }
		public DbSet<CourierRequest> CourierRequests { get; set; }
	}

	public class SampleDataSeeder
	{
		public static void Seed(KapoSelfCargoContext context)
		{
			context.Database.EnsureCreated();
			if (!context.CourierRequests.Any())
			{
				context.CourierRequests.AddRange(
					new CourierRequest
					{
						RequestNumber = "CR001",
						Sender = "Sender1",
						Recipient = "Recipient1",
						ShipmentType = "Express",
						Weight = "1 kg",
						ShipmentDate = "2024-02-05",
						DeliveryAddress = "Address1",
						DeliveryUrgency = "Urgent",
						Status = "Pending"
					},
					new CourierRequest
					{
						RequestNumber = "CR002",
						Sender = "Sender2",
						Recipient = "Recipient2",
						ShipmentType = "Standard",
						Weight = "2 kg",
						ShipmentDate = "2024-02-06",
						DeliveryAddress = "Address2",
						DeliveryUrgency = "Normal",
						Status = "In Transit"
					},
					new CourierRequest
					{
						RequestNumber = "CR003",
						Sender = "Sender3",
						Recipient = "Recipient3",
						ShipmentType = "Express",
						Weight = "3 kg",
						ShipmentDate = "2024-02-07",
						DeliveryAddress = "Address3",
						DeliveryUrgency = "Urgent",
						Status = "Delivered"
					},
					new CourierRequest
					{
						RequestNumber = "CR004",
						Sender = "Sender4",
						Recipient = "Recipient4",
						ShipmentType = "Standard",
						Weight = "4 kg",
						ShipmentDate = "2024-02-08",
						DeliveryAddress = "Address4",
						DeliveryUrgency = "Normal",
						Status = "Pending"
					},
					new CourierRequest
					{
						RequestNumber = "CR005",
						Sender = "Sender5",
						Recipient = "Recipient5",
						ShipmentType = "Express",
						Weight = "5 kg",
						ShipmentDate = "2024-02-09",
						DeliveryAddress = "Address5",
						DeliveryUrgency = "Urgent",
						Status = "In Transit"
					},
					new CourierRequest
					{
						RequestNumber = "CR006",
						Sender = "Sender6",
						Recipient = "Recipient6",
						ShipmentType = "Standard",
						Weight = "6 kg",
						ShipmentDate = "2024-02-10",
						DeliveryAddress = "Address6",
						DeliveryUrgency = "Normal",
						Status = "Delivered"
					},
					new CourierRequest
					{
						RequestNumber = "CR007",
						Sender = "Sender7",
						Recipient = "Recipient7",
						ShipmentType = "Express",
						Weight = "7 kg",
						ShipmentDate = "2024-02-11",
						DeliveryAddress = "Address7",
						DeliveryUrgency = "Urgent",
						Status = "Pending"
					},
					new CourierRequest
					{
						RequestNumber = "CR008",
						Sender = "Sender8",
						Recipient = "Recipient8",
						ShipmentType = "Standard",
						Weight = "8 kg",
						ShipmentDate = "2024-02-12",
						DeliveryAddress = "Address8",
						DeliveryUrgency = "Normal",
						Status = "In Transit"
					},
					new CourierRequest
					{
						RequestNumber = "CR009",
						Sender = "Sender9",
						Recipient = "Recipient9",
						ShipmentType = "Express",
						Weight = "9 kg",
						ShipmentDate = "2024-02-13",
						DeliveryAddress = "Address9",
						DeliveryUrgency = "Urgent",
						Status = "Delivered"
					},
					new CourierRequest
					{
						RequestNumber = "CR010",
						Sender = "Sender10",
						Recipient = "Recipient10",
						ShipmentType = "Standard",
						Weight = "10 kg",
						ShipmentDate = "2024-02-14",
						DeliveryAddress = "Address10",
						DeliveryUrgency = "Normal",
						Status = "Pending"
					}
				);
			}
			if (!context.Shipments.Any())
			{
				context.Shipments.AddRange(
					new Shipment
					{
						FirebaseId = "FID001",
						TrackingNumber = "TN001",
						Sender = "Sender1",
						Recipient = "Recipient1",
						ShippingCompany = "Company1",
						ShipmentStatus = "In Transit",
						ShipmentDate = "2024-02-05",
						EstimatedDeliveryDate = "2024-02-10",
						DeliveryDate = null,
						TotalCost = "100 USD"
					},
					new Shipment
					{
						FirebaseId = "FID002",
						TrackingNumber = "TN002",
						Sender = "Sender2",
						Recipient = "Recipient2",
						ShippingCompany = "Company2",
						ShipmentStatus = "Delivered",
						ShipmentDate = "2024-02-06",
						EstimatedDeliveryDate = "2024-02-12",
						DeliveryDate = "2024-02-10",
						TotalCost = "150 USD"
					},
					new Shipment
					{
						FirebaseId = "FID003",
						TrackingNumber = "TN003",
						Sender = "Sender3",
						Recipient = "Recipient3",
						ShippingCompany = "Company3",
						ShipmentStatus = "In Transit",
						ShipmentDate = "2024-02-07",
						EstimatedDeliveryDate = "2024-02-11",
						DeliveryDate = null,
						TotalCost = "120 USD"
					},
					new Shipment
					{
						FirebaseId = "FID004",
						TrackingNumber = "TN004",
						Sender = "Sender4",
						Recipient = "Recipient4",
						ShippingCompany = "Company4",
						ShipmentStatus = "Delivered",
						ShipmentDate = "2024-02-08",
						EstimatedDeliveryDate = "2024-02-13",
						DeliveryDate = "2024-02-11",
						TotalCost = "180 USD"
					},
					new Shipment
					{
						FirebaseId = "FID005",
						TrackingNumber = "TN005",
						Sender = "Sender5",
						Recipient = "Recipient5",
						ShippingCompany = "Company5",
						ShipmentStatus = "In Transit",
						ShipmentDate = "2024-02-09",
						EstimatedDeliveryDate = "2024-02-14",
						DeliveryDate = null,
						TotalCost = "130 USD"
					},
					new Shipment
					{
						FirebaseId = "FID006",
						TrackingNumber = "TN006",
						Sender = "Sender6",
						Recipient = "Recipient6",
						ShippingCompany = "Company6",
						ShipmentStatus = "Delivered",
						ShipmentDate = "2024-02-10",
						EstimatedDeliveryDate = "2024-02-15",
						DeliveryDate = "2024-02-12",
						TotalCost = "200 USD"
					},
					new Shipment
					{
						FirebaseId = "FID007",
						TrackingNumber = "TN007",
						Sender = "Sender7",
						Recipient = "Recipient7",
						ShippingCompany = "Company7",
						ShipmentStatus = "In Transit",
						ShipmentDate = "2024-02-11",
						EstimatedDeliveryDate = "2024-02-16",
						DeliveryDate = null,
						TotalCost = "140 USD"
					},
					new Shipment
					{
						FirebaseId = "FID008",
						TrackingNumber = "TN008",
						Sender = "Sender8",
						Recipient = "Recipient8",
						ShippingCompany = "Company8",
						ShipmentStatus = "Delivered",
						ShipmentDate = "2024-02-12",
						EstimatedDeliveryDate = "2024-02-17",
						DeliveryDate = "2024-02-14",
						TotalCost = "220 USD"
					},
					new Shipment
					{
						FirebaseId = "FID009",
						TrackingNumber = "TN009",
						Sender = "Sender9",
						Recipient = "Recipient9",
						ShippingCompany = "Company9",
						ShipmentStatus = "In Transit",
						ShipmentDate = "2024-02-13",
						EstimatedDeliveryDate = "2024-02-18",
						DeliveryDate = null,
						TotalCost = "160 USD"
					},
					new Shipment
					{
						FirebaseId = "FID010",
						TrackingNumber = "TN010",
						Sender = "Sender10",
						Recipient = "Recipient10",
						ShippingCompany = "Company10",
						ShipmentStatus = "Delivered",
						ShipmentDate = "2024-02-14",
						EstimatedDeliveryDate = "2024-02-19",
						DeliveryDate = "2024-02-16",
						TotalCost = "240 USD"
					}
				);
			}
			context.SaveChanges();
		}

	}
}
