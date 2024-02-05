namespace KapoSelfCargo.Customer.Api.Shared.ComplexTypes
{
	public enum ResponseCode
	{
		Success = 200,
		NotFound = 404,
		ValidationError = 422,
		InternalServerError = 500,
		Unauthorized = 401,
		Forbidden = 403,
		BadRequest = 400,
		Conflict = 409,
		NoContent = 204,
		NotImplemented = 501,
	}
}
