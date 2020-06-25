using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Forem.Api;
using Forem.Api.Models;

namespace Forem.Api
{
	public class VideosService : ApiService, IVideosService
	{
		public VideosService(Uri baseUri, HttpClient httpClient) : base(baseUri, httpClient) { }

		public Task<IEnumerable<Video>> GetVideosAsync(int page = 1, int perPage = 30)
			=> GetAsync<IEnumerable<Video>>("/api/videos", new Dictionary<string, object>
				{
					{ "page", page },
					{ "per_page", perPage },
				});
	}
}
