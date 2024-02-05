using KapoSelfCargo.Customer.Api.DataAccess;
using KapoSelfCargo.Customer.Api.Infrastructure.Model;
using KapoSelfCargo.Customer.Api.Infrastructure.Utility;
using KapoSelfCargo.Customer.Api.Shared.ComplexTypes;
using KapoSelfCargo.Customer.Api.Shared.Concrete;

namespace KapoSelfCargo.Customer.Api.BusinessUnit
{
	public interface IUserBusinessUnit
	{
		Task<Response> TAddAsync(User user);
	}
	public class UserBusinessUnit : IUserBusinessUnit
	{
		private readonly IUserDataAccess _userDataAccess;
		private readonly IUserUtility _userUtility;

		public UserBusinessUnit(IUserDataAccess userDataAccess, IUserUtility userUtility)
		{
			_userDataAccess = userDataAccess;
			_userUtility = userUtility;
		}

		public async Task<Response> TAddAsync(User user)
		{
			if (user == null)
			{
				return new Response(ResponseCode.BadRequest, "User is not valid");
			}
			var saveChangesValue = await _userDataAccess.AddAsync(user);
			if (saveChangesValue > 0)
			{
				return new Response(ResponseCode.Success, "User added successfully");
			}
			return new Response(ResponseCode.BadRequest, "User not added");
		}
	}
}
