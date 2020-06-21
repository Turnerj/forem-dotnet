using System;
using System.Net;

namespace Forem.Api
{
	public class ApiException : Exception
	{
		public ApiException(HttpStatusCode statusCode) : this((int)statusCode, statusCode.ToString()) { }
		public ApiException(int statusCode, string error) : base($"API returned error: {error}")
		{
			Data.Add("status", statusCode);
			Data.Add("error", error);
		}
	}
}
