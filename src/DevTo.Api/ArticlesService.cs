using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Forem.Api.Internal;
using Forem.Api.Models;

namespace Forem.Api
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

		public Task<IEnumerable<Article>> GetArticlesAsync(int page = 1, int perPage = 30)
			=> GetAsync<IEnumerable<Article>>("/api/articles", new Dictionary<string, object>
				{
					{ "page", page },
					{ "per_page", perPage },
				});

		public Task<IEnumerable<Article>> GetArticlesByTagAsync(string tag, int page = 1, int perPage = 30)
			=> GetAsync<IEnumerable<Article>>("/api/articles", new Dictionary<string, object>
				{
					{ "tag", tag },
					{ "page", page },
					{ "per_page", perPage },
				});

		public Task<IEnumerable<Article>> GetArticlesByUserAsync(string username, int page = 1, int perPage = 30)
			=> GetAsync<IEnumerable<Article>>("/api/articles", new Dictionary<string, object>
				{
					{ "username", username },
					{ "page", page },
					{ "per_page", perPage },
				});

		public Task<Article> GetArticleAsync(int id) => GetAsync<Article>($"/api/articles/{id}");

		private Task<IEnumerable<UserArticle>> GetUserArticlesAsync(string path, string apiKey, int page, int perPage)
			=> GetAsync<IEnumerable<UserArticle>>(path, new Dictionary<string, object>
				{
					{ "page", page },
					{ "per_page", perPage },
				}, apiKey);

		public Task<IEnumerable<UserArticle>> GetUserArticlesAsync(string apiKey, int page = 1, int perPage = 30)
			=> GetUserArticlesAsync("/api/articles/me", apiKey, page, perPage);

		public Task<IEnumerable<UserArticle>> GetUserPublishedArticlesAsync(string apiKey, int page = 1, int perPage = 30)
			=> GetUserArticlesAsync("/api/articles/me/published", apiKey, page, perPage);

		public Task<IEnumerable<UserArticle>> GetUserUnpublishedArticlesAsync(string apiKey, int page = 1, int perPage = 30)
			=> GetUserArticlesAsync("/api/articles/me/unpublished", apiKey, page, perPage);

		public Task<IEnumerable<UserArticle>> GetUserAllArticlesAsync(string apiKey, int page = 1, int perPage = 30)
			=> GetUserArticlesAsync("/api/articles/me/all", apiKey, page, perPage);
	}
}
