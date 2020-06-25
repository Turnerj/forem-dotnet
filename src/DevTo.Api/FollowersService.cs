using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Forem.Api.Models;

namespace Forem.Api
{
	public class FollowersService : ApiService, IFollowersService
	{
		public FollowersService(Uri baseUri, HttpClient httpClient) : base(baseUri, httpClient) { }

		public Task<IEnumerable<Follower>> GetUserFollowersAsync(string apiKey, int page = 1, int perPage = 80)
			=> GetAsync<IEnumerable<Follower>>("/api/followers/users", new Dictionary<string, object>
				{
					{ "page", page },
					{ "per_page", perPage },
				}, apiKey);
	}
}
