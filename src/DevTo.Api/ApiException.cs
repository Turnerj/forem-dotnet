using System;
using System.Collections.Generic;
using System.Text;

namespace DevTo.Api
{
	public class ApiException : Exception
	{
		public ApiException(int statusCode, string error) : base($"API returned error: {error}")
		{
			Data.Add("status", statusCode);
			Data.Add("error", error);
		}
	}
}
