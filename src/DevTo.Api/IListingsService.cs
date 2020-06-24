using System.Collections.Generic;
using System.Threading.Tasks;
using Forem.Api.Models.Listing;

namespace Forem.Api
{
	public interface IListingsService
	{
		/// <summary>
		/// Retrieves a list of listings.
		/// </summary>
		/// <param name="page">The page number for the listings.</param>
		/// <param name="perPage">Page size (the number of items to return per page).</param>
		/// <returns></returns>
		Task<IEnumerable<Listing>> GetListingsAsync(int page, int perPage);
		/// <summary>
		/// Creates a listing. Returns the new created listing.
		/// </summary>
		/// <param name="apiKey">The API key associated to the account that the listing is created under.</param>
		/// <param name="properties">The properties for the listing object to create.</param>
		/// <param name="action">The create action (null If normal creating, Draft for unpublished listing).</param>
		/// <returns></returns>
		Task<Listing> CreateListingAsync(string apiKey, ListingProperties properties, ListingAction action);
		/// <summary>
		/// Retrieves a list of listings, filtered by category.
		/// </summary>
		/// <param name="category">The requested category for the listings.</param>
		/// <param name="page">The page number for the listings.</param>
		/// <param name="perPage">Page size (the number of items to return per page).</param>
		/// <returns></returns>
		Task<IEnumerable<Listing>> GetListingsByCategoryAsync(ListingCategory category, int page, int perPage);
		/// <summary>
		/// Retrieves a single listing given its ID.
		/// </summary>
		/// <param name="id">The listing ID.</param>
		/// <returns></returns>
		Task<Listing> GetListingAsync(long id);
		/// <summary>
		/// Updates a listing. Returns the updated listing.
		/// </summary>
		/// <param name="apiKey">The API key associated to the account that the listing is created under.</param>
		/// <param name="id">The listing ID.</param>
		/// <param name="action">The update action.</param>
		/// <param name="properties">The listing properties to update.</param>
		/// <returns></returns>
		Task<CompleteListing> UpdateListingAsync(string apiKey, long id, ListingAction action, ListingProperties properties);
	}
}
