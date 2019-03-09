using DevTo.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevTo.Api
{
	public interface IArticleApi
	{
		Task<IEnumerable<ArticleListing>> GetArticlesAsync(int page = 1);
		Task<IEnumerable<ArticleListing>> GetArticlesByTagAsync(string tag, int page = 1);
		Task<IEnumerable<ArticleListing>> GetArticlesByUserAsync(string username, int page = 1);
		Task<Article> GetArticleAsync(int id);
	}
}
