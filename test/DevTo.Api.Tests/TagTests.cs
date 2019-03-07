using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevTo.Api.Tests
{
	[TestClass]
	public class TagTests : TestBase
	{
		[TestMethod]
		public async Task GetTags()
		{
			var tagService = new TagService(BaseUri, HttpClient);
			var tags = await tagService.GetTagsAsync();
			Assert.IsNotNull(tags);
		}
	}
}
