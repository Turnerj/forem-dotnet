using System;
using System.Net.Http;

namespace Forem.Api.Tests
{
	public class TestBase
	{
		protected HttpClient HttpClient { get; } = new HttpClient();
		protected Uri BaseUri { get; } = new Uri("https://dev.to/");
	}
}
