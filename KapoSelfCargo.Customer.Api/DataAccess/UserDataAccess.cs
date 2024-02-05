using KapoSelfCargo.Customer.Api.Infrastructure;
using KapoSelfCargo.Customer.Api.Infrastructure.Model;

namespace KapoSelfCargo.Customer.Api.DataAccess
{
	public interface IUserDataAccess
	{
		Task<int> AddAsync(User user);
	}
	public class UserDataAccess : IUserDataAccess
	{
		private readonly KapoSelfCargoContext _context;
		public UserDataAccess(KapoSelfCargoContext context)
		{
			_context = context;
		}
		public async Task<int> AddAsync(User user)
		{
			_context.Users.AddAsync(user);
			return await _context.SaveChangesAsync();
		}
	}
}
