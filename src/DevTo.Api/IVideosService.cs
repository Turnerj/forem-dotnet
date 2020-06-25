using Forem.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forem.Api
{
	public interface IVideosService
	{
		/// <summary>
		/// Retrieve a list of articles that are uploaded with a video.
		/// </summary>
		/// <param name="page">Pagination page.</param>
		/// <param name="perPage">Page size (the number of items to return per page).</param>
		/// <returns></returns>
		Task<IEnumerable<Video>> GetVideosAsync(int page, int perPage);
	}
}
