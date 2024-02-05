using KapoSelfCargo.Customer.Api.Infrastructure;
using KapoSelfCargo.Customer.Api.Infrastructure.Model;

namespace KapoSelfCargo.Customer.Api.DataAccess
{
	public interface ICourierRequestDataAccess
	{
		Task<int> Add(CourierRequest courierRequest);
	}
	public class CourierRequestDataAccess : ICourierRequestDataAccess
	{
		private readonly KapoSelfCargoContext _context;

		public CourierRequestDataAccess(KapoSelfCargoContext context)
		{
			_context = context;
		}

		public async Task<int> Add(CourierRequest courierRequest)
		{
			_context.Add(courierRequest);
			return await _context.SaveChangesAsync();
		}
	}
}
