using Forem.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forem.Api.Interfaces
{
	public interface IPodcastEpisodesApi
	{
		/// <summary>
		/// Retrieves active podcast episodes that belong to published podcasts available on the platform, ordered by descending publication date.
		/// </summary>
		/// <param name="username">Using this parameter will retrieve episodes belonging to a specific podcast.</param>		
		/// <param name="page">Pagination page.</param>
		/// <param name="perPage">Page size (the number of items to return per page).</param>
		/// <returns></returns>
		Task<IEnumerable<PodcastEpisode>> GetPodcastEpisodesAsync(string username, int page, int perPage);
	}
}
