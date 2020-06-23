using Forem.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forem.Api.Interfaces
{
	public interface IFollowersApi
	{
		/// <summary>
		/// Retrieves a list of the followers they have.
		/// </summary>
		/// <param name="apiKey">The API key associated to the account.</param>
		/// <param name="page">Pagination page.</param>
		/// <param name="perPage">Page size (the number of items to return per page).</param>
		/// <returns></returns>
		Task<IEnumerable<Follower>> GetUserFollowersAsync(string apiKey, int page, int perPage);
	}
}
