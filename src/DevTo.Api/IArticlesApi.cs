using DevTo.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevTo.Api
{
	public interface IArticlesApi
	{
		Task<Article> CreateArticleAsync(string apiKey, string markdown);
		Task<Article> UpdateArticleAsync(string apiKey, int id, string markdown);
		Task<IEnumerable<ArticleListing>> GetArticlesAsync(int page = 1);
		Task<IEnumerable<ArticleListing>> GetArticlesByTagAsync(string tag, int page = 1);
		Task<IEnumerable<ArticleListing>> GetArticlesByUserAsync(string username, int page = 1);
		Task<Article> GetArticleAsync(int id);
	}
}
