using Forem.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forem.Api
{
	public interface IArticlesApi
	{
		/// <summary>
		/// Creates an article with the given markdown. Returns the new created article.
		/// </summary>
		/// <param name="apiKey">The API key associated to the account that the article is created under.</param>
		/// <param name="markdown">The article body, including any front matter.</param>
		/// <returns></returns>
		Task<UserArticle> CreateArticleAsync(string apiKey, string markdown);
		/// <summary>
		/// Updates the article with the specified ID. Returns the updated article.
		/// </summary>
		/// <param name="apiKey">The API key associated to the account that the article is created under.</param>
		/// <param name="id">The existing article ID.</param>
		/// <param name="markdown">The article body, including any front matter.</param>
		/// <returns></returns>
		Task<UserArticle> UpdateArticleAsync(string apiKey, int id, string markdown);
		/// <summary>
		/// Retrieves articles created by the authorized user.
		/// </summary>
		/// <param name="apiKey">The API key associated to the account that these articles are created under.</param>
		/// <param name="page">The page number for the articles.</param>
		/// <returns></returns>
		Task<IEnumerable<UserArticle>> GetUserArticlesAsync(string apiKey, int page = 1);
		/// <summary>
		/// Retrieves all published articles, ordered by descending popularity.
		/// </summary>
		/// <param name="page">The page number for the articles.</param>
		/// <returns></returns>
		Task<IEnumerable<Article>> GetArticlesAsync(int page = 1);
		/// <summary>
		/// Retrieves published articles with the given tag, ordered by descending popularity.
		/// </summary>
		/// <param name="tag">A tag associated to the articles.</param>
		/// <param name="page">The page number for the articles.</param>
		/// <returns></returns>
		Task<IEnumerable<Article>> GetArticlesByTagAsync(string tag, int page = 1);
		/// <summary>
		/// Retrieves published articles by the given user, ordered by published date.
		/// </summary>
		/// <param name="username">The username associated to the articles.</param>
		/// <param name="page">The page number for the articles.</param>
		/// <returns></returns>
		Task<IEnumerable<Article>> GetArticlesByUserAsync(string username, int page = 1);
		/// <summary>
		/// Retrieves an article with the specified article ID.
		/// </summary>
		/// <param name="id">The article ID.</param>
		/// <returns></returns>
		Task<Article> GetArticleAsync(int id);
	}
}
