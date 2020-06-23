using Forem.Api.Models;
using Forem.Api.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Forem.Api.Tests
{
	[TestClass]
	public class WebhooksApiTests : TestBase
	{
		[TestMethod, ExpectedException(typeof(ApiException))]
		public async Task GetWebhooks_WithInvalidApiKeyThrowsException()
		{
			var webhookService = new WebhooksService(BaseUri, HttpClient);
			await webhookService.GetWebhooksAsync("NotARealApiKey");
		}

		[TestMethod, ExpectedException(typeof(ApiException))]
		public async Task CreateWebhook_WithInvalidApiKeyThrowsException()
		{
			var webhookService = new WebhooksService(BaseUri, HttpClient);
			await webhookService.CreateWebhookAsync("NotARealApiKey", "source", "targetURL", null);
		}

		[TestMethod, ExpectedException(typeof(ApiException))]
		public async Task GetWebhook_WithInvalidApiKeyThrowsException()
		{
			var webhookService = new WebhooksService(BaseUri, HttpClient);
			await webhookService.GetWebhookAsync("NotARealApiKey", 1);
		}

		[TestMethod, ExpectedException(typeof(ApiException))]
		public async Task DeleteWebhook_WithInvalidApiKeyThrowsException()
		{
			var webhookService = new WebhooksService(BaseUri, HttpClient);
			await webhookService.DeleteWebhookAsync("NotARealApiKey", 1);
		}
	}
}
