using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Forem.Api.Tests
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

		[TestMethod, ExpectedException(typeof(ApiException))]
		public async Task GetUserPublishedArticles_WithInvalidApiKeyThrowsException()
		{
			var articleService = new ArticlesService(BaseUri, HttpClient);
			await articleService.GetUserPublishedArticlesAsync("NotARealApiKey");
		}

		[TestMethod, ExpectedException(typeof(ApiException))]
		public async Task GetUserUnpublishedArticles_WithInvalidApiKeyThrowsException()
		{
			var articleService = new ArticlesService(BaseUri, HttpClient);
			await articleService.GetUserUnpublishedArticlesAsync("NotARealApiKey");
		}

		[TestMethod, ExpectedException(typeof(ApiException))]
		public async Task GetUserAllArticles_WithInvalidApiKeyThrowsException()
		{
			var articleService = new ArticlesService(BaseUri, HttpClient);
			await articleService.GetUserAllArticlesAsync("NotARealApiKey");
		}

		[TestMethod]
		public async Task GetArticles()
		{
			var articleService = new ArticlesService(BaseUri, HttpClient);
			var articles = await articleService.GetArticlesAsync();
			Assert.IsTrue(articles.Any());
		}
		
		[TestMethod]
		public async Task GetArticlesWithPagination()
		{
			var articleService = new ArticlesService(BaseUri, HttpClient);
			var firstPageOfArticles = await articleService.GetArticlesAsync(1);
			var secondPageOfArticles = await articleService.GetArticlesAsync(2);
			Assert.IsTrue(firstPageOfArticles.Any());
			Assert.IsTrue(secondPageOfArticles.Any());
			Assert.AreNotEqual(firstPageOfArticles.First().ArticleId, secondPageOfArticles.First().ArticleId);
		}

		[TestMethod]
		public async Task GetArticlesByTag()
		{
			var articleService = new ArticlesService(BaseUri, HttpClient);
			var articles = await articleService.GetArticlesByTagAsync("react");
			Assert.IsNotNull(articles);
			Assert.IsTrue(articles.All(a => a.TagList.Contains("react", StringComparer.OrdinalIgnoreCase)));
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
