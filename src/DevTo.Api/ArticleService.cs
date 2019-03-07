using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DevTo.Api.Models;

namespace DevTo.Api
{
	public class ArticleService : ApiService, IArticleApi
	{
		public ArticleService(Uri baseUri, HttpClient httpClient) : base(baseUri, httpClient) { }

		public async Task<Article> GetArticleAsync(int id)
		{
			return await GetAsync<Article>($"/api/articles/{id}");
		}

		public async Task<IEnumerable<ArticleListing>> GetRecentArticlesAsync(int page = 1)
		{
			return await GetAsync<IEnumerable<ArticleListing>>("/api/articles", new
			{
				page
			});
		}

		public async Task<IEnumerable<ArticleListing>> GetRecentArticlesForTagAsync(string tag, int page = 1)
		{
			return await GetAsync<IEnumerable<ArticleListing>>("/api/articles", new
			{
				tag,
				page
			});
		}
	}
}
