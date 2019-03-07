using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DevTo.Api.Tests
{
	[TestClass]
	public class ArticleTests : TestBase
	{
		[TestMethod]
		public async Task GetArticles()
		{
			var articleService = new ArticleService(BaseUri, HttpClient);
			var articles = await articleService.GetRecentArticlesAsync();
			Assert.IsNotNull(articles);
		}
	}
}
