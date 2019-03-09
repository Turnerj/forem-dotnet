using DevTo.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevTo.Api
{
	public interface IArticleApi
	{
		Task<IEnumerable<ArticleListing>> GetRecentArticlesAsync(int page = 1);
		Task<IEnumerable<ArticleListing>> GetRecentArticlesForTagAsync(string tagName, int page = 1);
		Task<IEnumerable<ArticleListing>> GetArticlesForUserAsync(string username, int page = 1);
		Task<Article> GetArticleAsync(int id);
	}
}
