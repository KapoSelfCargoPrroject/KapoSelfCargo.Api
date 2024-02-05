
using KapoSelfCargo.Customer.Api.Shared.ComplexTypes;

namespace KapoSelfCargo.Customer.Api.Shared.Abstract
{
	public interface IServiceResponse
	{
		ResponseCode ResponseCode { get; }
		string Message { get; }
	}
}
