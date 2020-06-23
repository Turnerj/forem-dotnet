using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Forem.Api.Interfaces;
using Forem.Api.Models;

namespace Forem.Api.Services
{
	public class TagsService : ApiService, ITagsApi
	{
		public TagsService(Uri baseUri, HttpClient httpClient) : base(baseUri, httpClient) { }

		public Task<IEnumerable<Tag>> GetTagsAsync(int page = 1, int perPage = 10)
			=> GetAsync<IEnumerable<Tag>>("/api/tags", new Dictionary<string, object>
				{
					{ "page", page },
					{ "per_page", perPage },
				});
	}
}
