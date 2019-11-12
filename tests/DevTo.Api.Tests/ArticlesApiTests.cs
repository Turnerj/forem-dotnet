using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DevTo.Api.Tests
{
	[TestClass]
	public class ArticlesApiTests : TestBase
	{
		[TestMethod, ExpectedException(typeof(ApiException))]
		public async Task CreateArticle_WithInvalidApiKeyThrowsException()
		{
			var articleService = new ArticlesService(BaseUri, HttpClient);
			await articleService.CreateArticleAsync("NotARealApiKey", "Hello World");
		}

		[TestMethod, ExpectedException(typeof(ApiException))]
		public async Task UpdateArticle_WithInvalidApiKeyThrowsException()
		{
			var articleService = new ArticlesService(BaseUri, HttpClient);
			await articleService.UpdateArticleAsync("NotARealApiKey", 5, "Hello World");
		}

		[TestMethod, ExpectedException(typeof(ApiException))]
		public async Task GetUserArticles_WithInvalidApiKeyThrowsException()
		{
			var articleService = new ArticlesService(BaseUri, HttpClient);
			await articleService.GetUserArticlesAsync("NotARealApiKey");
		}

		[TestMethod]
		public async Task GetArticles()
		{
			var articleService = new ArticlesService(BaseUri, HttpClient);
			var articles = await articleService.GetArticlesAsync();
			Assert.IsNotNull(articles);
		}
		
		[TestMethod]
		public async Task GetArticlesWithPagination()
		{
			var articleService = new ArticlesService(BaseUri, HttpClient);
			var firstPageOfArticles = (await articleService.GetArticlesAsync(1)).ToArray();
			var secondPageOfArticles = (await articleService.GetArticlesAsync(2)).ToArray();
			Assert.IsNotNull(firstPageOfArticles);
			Assert.IsNotNull(secondPageOfArticles);
			Assert.AreNotEqual(firstPageOfArticles[0].ArticleId, secondPageOfArticles[0].ArticleId);
		}

		[TestMethod]
		public async Task GetArticlesByTag()
		{
			var articleService = new ArticlesService(BaseUri, HttpClient);
			var articles = await articleService.GetArticlesByTagAsync("react");
			Assert.IsNotNull(articles);
			Assert.IsTrue(articles.All(a => a.TagList.Contains("react")));
		}

		[TestMethod]
		public async Task GetArticle()
		{
			var articleService = new ArticlesService(BaseUri, HttpClient);
			var article = await articleService.GetArticleAsync(5);
			Assert.IsNotNull(article);
		}

		[TestMethod]
		public async Task GetArticlesByUser()
		{
			var articleService = new ArticlesService(BaseUri, HttpClient);
			var articles = await articleService.GetArticlesByUserAsync("ben");
			Assert.IsTrue(articles.Any());
		}
	}
}
