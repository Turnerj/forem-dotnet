using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Forem.Api.Models;

namespace Forem.Api
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
