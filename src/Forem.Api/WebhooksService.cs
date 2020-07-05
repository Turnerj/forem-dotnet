using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Forem.Api.Models;

namespace Forem.Api
{
	public class WebhooksService : ApiService, IWebhooksService
	{
		public WebhooksService(Uri baseUri, HttpClient httpClient) : base(baseUri, httpClient) { }

		public Task<IEnumerable<Webhook>> GetWebhooksAsync(string apiKey) => GetAsync<IEnumerable<Webhook>>("/api/webhooks", null, apiKey);

		public Task<Webhook> CreateWebhookAsync(string apiKey, string source, string targetUrl, IEnumerable<string> events)
		{
			var webhook = new Dictionary<string, object>();
			webhook.Add("source", source);
			webhook.Add("target_url", targetUrl);
			webhook.Add("events", events);

			return PostAsync<Webhook>("/api/webhooks", new Dictionary<string, object> { { "webhook_endpoint", webhook } }, apiKey);
		}

		public Task<Webhook> GetWebhookAsync(string apiKey, long id) => GetAsync<Webhook>($"/api/webhooks/{id}", null, apiKey);

		public Task DeleteWebhookAsync(string apiKey, long id) => DeleteAsync<Task>($"/api/webhooks/{id}", apiKey);
	}
}
