using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DevTo.Api.Tests
{
	[TestClass]
	public class ArticleTests : TestBase
	{
		[TestMethod]
		public async Task GetRecentArticles()
		{
			var articleService = new ArticleService(BaseUri, HttpClient);
			var articles = await articleService.GetRecentArticlesAsync();
			Assert.IsNotNull(articles);
		}
		
		[TestMethod]
		public async Task GetRecentArticlesWithPagination()
		{
			var articleService = new ArticleService(BaseUri, HttpClient);
			var firstPageOfArticles = (await articleService.GetRecentArticlesAsync(1)).ToArray();
			var secondPageOfArticles = (await articleService.GetRecentArticlesAsync(2)).ToArray();
			Assert.IsNotNull(firstPageOfArticles);
			Assert.IsNotNull(secondPageOfArticles);
			Assert.AreNotEqual(firstPageOfArticles[0].ArticleId, secondPageOfArticles[0].ArticleId);
		}

		[TestMethod]
		public async Task GetRecentArticlesForTag()
		{
			var articleService = new ArticleService(BaseUri, HttpClient);
			var articles = await articleService.GetRecentArticlesForTagAsync("react");
			Assert.IsNotNull(articles);
			Assert.IsTrue(articles.All(a => a.TagList.Contains("react")));
		}

		[TestMethod]
		public async Task GetArticle()
		{
			var articleService = new ArticleService(BaseUri, HttpClient);
			var article = await articleService.GetArticleAsync(5);
			Assert.IsNotNull(article);
		}
	}
}
