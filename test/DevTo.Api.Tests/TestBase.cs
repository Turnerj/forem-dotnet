using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DevTo.Api.Tests
{
	public class TestBase
	{
		protected HttpClient HttpClient { get; } = new HttpClient();
		protected Uri BaseUri { get; } = new Uri("https://dev.to/");
	}
}
