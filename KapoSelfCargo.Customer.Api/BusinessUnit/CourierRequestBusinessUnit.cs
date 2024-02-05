using KapoSelfCargo.Customer.Api.DataAccess;
using KapoSelfCargo.Customer.Api.Infrastructure.Model;
using KapoSelfCargo.Customer.Api.Shared.ComplexTypes;
using KapoSelfCargo.Customer.Api.Shared.Concrete;

namespace KapoSelfCargo.Customer.Api.BusinessUnit
{
	public interface ICourierRequestBusinessUnit
	{
		Task<Response> TAddAsync(CourierRequest courierRequest);
	}
	public class CourierRequestBusinessUnit : ICourierRequestBusinessUnit
	{
		private readonly ICourierRequestDataAccess _courierRequestDataAccess;
		public CourierRequestBusinessUnit(ICourierRequestDataAccess courierRequestDataAccess)
		{
			_courierRequestDataAccess = courierRequestDataAccess;
		}
		public async Task<Response> TAddAsync(CourierRequest courierRequest)
		{
			try
			{
				if (courierRequest == null)
				{
					return new Response(ResponseCode.BadRequest, "Invalid request. The courier request cannot be null.");
				}
				var saveChangesValue = await _courierRequestDataAccess.Add(courierRequest);
				if (saveChangesValue > 0)
				{
					return new Response(ResponseCode.Success, "Courier request added successfully.");
				}
				return new Response(ResponseCode.BadRequest, "Failed to add courier request. Please try again.");
			}
			catch
			{
				return new Response(ResponseCode.InternalServerError, "An unexpected error occurred while processing the request.");
			}
		}
	}
}
