using DevTo.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevTo.Api
{
	public interface IArticlesApi
	{
		Task<UserArticle> CreateArticleAsync(string apiKey, string markdown);
		Task<UserArticle> UpdateArticleAsync(string apiKey, int id, string markdown);
		Task<IEnumerable<UserArticle>> GetUserArticlesAsync(string apiKey, int page = 1);

		Task<IEnumerable<Article>> GetArticlesAsync(int page = 1);
		Task<IEnumerable<Article>> GetArticlesByTagAsync(string tag, int page = 1);
		Task<IEnumerable<Article>> GetArticlesByUserAsync(string username, int page = 1);
		Task<Article> GetArticleAsync(int id);
	}
}
