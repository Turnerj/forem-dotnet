using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DevTo.Api.Models;

namespace DevTo.Api
{
	public class TagService : ApiService, ITagsApi
	{
		public TagService(Uri baseUri, HttpClient httpClient) : base(baseUri, httpClient) { }

		public async Task<IEnumerable<Tag>> GetTagsAsync(int page = 1)
		{
			return await GetAsync<IEnumerable<Tag>>("/api/tags", new
			{
				page
			});
		}
	}
}
