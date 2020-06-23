using System.Collections.Generic;
using System.Threading.Tasks;
using Forem.Api.Models;

namespace Forem.Api.Interfaces
{
	public interface IWebhooksApi
	{
		/// <summary>
		/// Retrieves a list of webhooks they have previously registered.
		/// </summary>
		/// <param name="apiKey">The API key associated to the account that the webhooks are created under.</param>
		/// <returns></returns>
		Task<IEnumerable<Webhook>> GetWebhooksAsync(string apiKey);
		/// <summary>
		/// Creates a webhook. Returns the new created webhook.
		/// </summary>
		/// <param name="apiKey">The API key associated to the account that the webhook is created under.</param>
		/// <param name="source">The name of the requester.</param>
		/// <param name="targetUrl">Webhook target URL.</param>
		/// <param name="events">An array of events like "article_created", "article_updated".</param>
		/// <returns></returns>
		Task<Webhook> CreateWebhookAsync(string apiKey, string source, string targetUrl, IEnumerable<string> events);
		/// <summary>
		/// Retrieves a single webhook given its ID.
		/// </summary>
		/// <param name="apiKey">The API key associated to the account that the webhook is created under.</param>
		/// <param name="id">Id of the webhook.</param>
		/// <returns></returns>
		Task<Webhook> GetWebhookAsync(string apiKey, long id);
		/// <summary>
		/// Delete a single webhook given its ID.
		/// </summary>
		/// <param name="apiKey">The API key associated to the account that the webhook is created under.</param>
		/// <param name="id">Id of the webhook.</param>
		/// <returns></returns>
		Task DeleteWebhookAsync(string apiKey, long id);
	}
}
