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

		public Task<UserArticle> CreateArticleAsync(string apiKey, string markdown)
		{
			return PutAsync<UserArticle>("/api/articles", new ArticleUpdate
			{
				Article = new ArticleUpdate.ArticlePayload
				{
					Markdown = markdown
				}
			}, apiKey);
		}

		public Task<UserArticle> UpdateArticleAsync(string apiKey, int id, string markdown)
		{
			return PutAsync<UserArticle>($"/api/articles/{id}", new ArticleUpdate
			{
				Article = new ArticleUpdate.ArticlePayload
				{
					Markdown = markdown
				}
			}, apiKey);
		}

		public Task<IEnumerable<UserArticle>> GetUserArticlesAsync(string apiKey, int page = 1)
		{
			return GetAsync<IEnumerable<UserArticle>>($"/api/me/all", new
			{
				page
			}, apiKey);
		}

		public Task<Article> GetArticleAsync(int id)
		{
			return GetAsync<Article>($"/api/articles/{id}");
		}

		public Task<IEnumerable<Article>> GetArticlesAsync(int page = 1)
		{
			return GetAsync<IEnumerable<Article>>("/api/articles", new
			{
				page
			});
		}

		public Task<IEnumerable<Article>> GetArticlesByTagAsync(string tag, int page = 1)
		{
			return GetAsync<IEnumerable<Article>>("/api/articles", new
			{
				tag,
				page
			});
		}

		public Task<IEnumerable<Article>> GetArticlesByUserAsync(string username, int page = 1)
		{
			return GetAsync<IEnumerable<Article>>("/api/articles", new
			{
				username,
				page
			});
		}
	}
}
