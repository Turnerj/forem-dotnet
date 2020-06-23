using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Forem.Api.Interfaces;
using Forem.Api.Models;

namespace Forem.Api.Services
{
	public class VideosService : ApiService, IVideosApi
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
