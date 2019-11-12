using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DevTo.Api.Internal;
using DevTo.Api.Models;

namespace DevTo.Api
{
	public class ArticlesService : ApiService, IArticlesApi
	{
		public ArticlesService(Uri baseUri, HttpClient httpClient) : base(baseUri, httpClient) { }

		public async Task<Article> CreateArticleAsync(string apiKey, string markdown)
		{
			return await PutAsync<Article>("/api/articles", new ArticleUpdate
			{
				Article = new ArticleUpdate.ArticlePayload
				{
					Markdown = markdown
				}
			}, apiKey);
		}

		public async Task<Article> UpdateArticleAsync(string apiKey, int id, string markdown)
		{
			return await PutAsync<Article>($"/api/articles/{id}", new ArticleUpdate
			{
				Article = new ArticleUpdate.ArticlePayload
				{
					Markdown = markdown
				}
			}, apiKey);
		}

		public async Task<Article> GetArticleAsync(int id)
		{
			return await GetAsync<Article>($"/api/articles/{id}");
		}

		public async Task<IEnumerable<ArticleListing>> GetArticlesAsync(int page = 1)
		{
			return await GetAsync<IEnumerable<ArticleListing>>("/api/articles", new
			{
				page
			});
		}

		public async Task<IEnumerable<ArticleListing>> GetArticlesByTagAsync(string tag, int page = 1)
		{
			return await GetAsync<IEnumerable<ArticleListing>>("/api/articles", new
			{
				tag,
				page
			});
		}

		public async Task<IEnumerable<ArticleListing>> GetArticlesByUserAsync(string username, int page = 1)
		{
			return await GetAsync<IEnumerable<ArticleListing>>("/api/articles", new
			{
				username,
				page
			});
		}
	}
}
