using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Forem.Api.Models;
using Forem.Api.Models.Listing;
using Newtonsoft.Json;

namespace Forem.Api
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

		private dynamic CreateRequestPayload(ListingProperties properties, ListingAction action)
		{
			var listing = new ExpandoObject() as IDictionary<string, object>;

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

					var props = properties.GetType().GetProperties();

					foreach (var prop in props)
					{
						if (prop.GetValue(properties) != null)
						{
							var jsonProp = prop.GetCustomAttributes().First() as JsonPropertyAttribute;

							listing.Add(jsonProp.PropertyName, prop.GetValue(properties));
						}
					}

					break;
			}

			return new { listing };
		}
	}
}
