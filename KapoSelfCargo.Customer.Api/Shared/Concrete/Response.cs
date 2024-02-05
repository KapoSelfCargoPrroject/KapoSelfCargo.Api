﻿using KapoSelfCargo.Customer.Api.Shared.Abstract;
using KapoSelfCargo.Customer.Api.Shared.ComplexTypes;

namespace KapoSelfCargo.Customer.Api.Shared.Concrete
{
	public class Response<T> : IServiceResponse
	{
		public ResponseCode ResponseCode { get; }
		public string Message { get; }
		public T Data { get; }
		public Response(ResponseCode responseCode, string message)
		{
			ResponseCode = responseCode;
			Message = message;
		}

		public Response(ResponseCode responseCode, T data)
		{
			ResponseCode = responseCode;
			Data = data;
			Message = ResponseCode.ToString();
		}

		public Response(ResponseCode responseCode, string message, T data)
		{
			ResponseCode = responseCode;
			Message = message;
			Data = data;
		}
	}

	public class Response : IServiceResponse
	{
		public ResponseCode ResponseCode { get; }
		public string Message { get; }
		public Response(ResponseCode responseCode, string message)
		{
			ResponseCode = responseCode;
			Message = message;
		}

		public Response(ResponseCode responseCode)
		{
			ResponseCode = responseCode;
			Message = ResponseCode.ToString();
		}
	}
}
