using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace KapoSelfCargo.Customer.Api.Infrastructure.Model
{
	public class User
	{
		[Key]
		public int Id { get; set; }
		public string? FirebaseId { get; set; }
		public string? Email { get; set; }
	}
}
