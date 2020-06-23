using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Forem.Api.Interfaces;
using Forem.Api.Models.Listing;

namespace Forem.Api.Services
{
	public class ListingsService : ApiService, IListingsApi
	{
		public ListingsService(Uri baseUri, HttpClient httpClient) : base(baseUri, httpClient) { }

		public Task<IEnumerable<Listing>> GetListingsAsync(int page = 1, int perPage = 30)
			=> GetAsync<IEnumerable<Listing>>("/api/listings", new Dictionary<string, object>
				{
					{ "page", page },
					{ "per_page", perPage },
				});

		public Task<Listing> CreateListingAsync(string apiKey, ListingProperties properties, ListingAction action = ListingAction.Create)
			=> PostAsync<Listing>("/api/listings", CreateRequestPayload(properties, action), apiKey);

		public Task<IEnumerable<Listing>> GetListingsByCategoryAsync(ListingCategory category, int page = 1, int perPage = 30)
			=> GetAsync<IEnumerable<Listing>>($"/api/listings/category/{category}", new Dictionary<string, object>
				{
					{ "page", page },
					{ "per_page", perPage },
				});

		public Task<Listing> GetListingAsync(long id) => GetAsync<Listing>($"/api/listings/{id}");

		public Task<CompleteListing> UpdateListingAsync(string apiKey, long id, ListingAction action, ListingProperties properties = null)
			=> PutAsync<CompleteListing>($"/api/listings/{id}", CreateRequestPayload(properties, action), apiKey);

		private IDictionary<string, object> CreateRequestPayload(ListingProperties properties, ListingAction action)
		{
			var listing = new Dictionary<string, object>();

			switch (action)
			{
				case ListingAction.Bump:
				case ListingAction.Publish:
				case ListingAction.Unpublish:
					listing.Add("action", action);
					break;

				case ListingAction.Create:
				case ListingAction.Draft:
				case ListingAction.Update:
					if (action == ListingAction.Draft)
					{
						listing.Add("action", action);
					}

					if (!string.IsNullOrEmpty(properties.Title))
					{
						listing.Add("title", properties.Title);
					}

					if (!string.IsNullOrEmpty(properties.BodyMarkdown))
					{
						listing.Add("body_markdown", properties.BodyMarkdown);
					}

					if (properties.Category != null)
					{
						listing.Add("category", properties.Category);
					}

					if (properties.Tags != null)
					{
						listing.Add("tags", properties.Tags);
					}

					if (properties.ExpiresAt != null)
					{
						listing.Add("expires_at", properties.ExpiresAt);
					}

					if (properties.ContactViaConnect != null)
					{
						listing.Add("contact_via_connect", properties.ContactViaConnect);
					}

					if (properties.Location != null)
					{
						listing.Add("location", properties.Location);
					}

					if (properties.OrganizationId != null)
					{
						listing.Add("organization_id", properties.OrganizationId);
					}

					break;
			}

			return new Dictionary<string, object> {{ "listing", listing }};
		}
	}
}
