using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DevTo.Api.Tests
{
	[TestClass]
	public class CommentsApiTests : TestBase
	{
		[TestMethod]
		public async Task GetComments()
		{
			var commentsService = new CommentsService(BaseUri, HttpClient);
			var comments = await commentsService.GetCommentsByArticleAsync(5);
			Assert.IsNotNull(comments);
		}

		[TestMethod]
		public async Task GetComment()
		{
			var commentsService = new CommentsService(BaseUri, HttpClient);
			var comment = await commentsService.GetCommentAsync("m3m0");
			Assert.IsNotNull(comment);
		}
	}
}
