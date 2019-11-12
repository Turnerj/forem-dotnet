using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DevTo.Api.Models;

namespace DevTo.Api
{
	public class TagsService : ApiService, ITagsApi
	{
		public TagsService(Uri baseUri, HttpClient httpClient) : base(baseUri, httpClient) { }

		public Task<IEnumerable<Tag>> GetTagsAsync(int page = 1)
		{
			return GetAsync<IEnumerable<Tag>>("/api/tags", new
			{
				page
			});
		}
	}
}
