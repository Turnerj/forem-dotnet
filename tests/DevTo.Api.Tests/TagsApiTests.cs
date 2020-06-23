using System.Threading.Tasks;
using Forem.Api.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Forem.Api.Tests
{
	[TestClass]
	public class TagsApiTests : TestBase
	{
		[TestMethod]
		public async Task GetTags()
		{
			var tagService = new TagsService(BaseUri, HttpClient);
			var tags = await tagService.GetTagsAsync();
			Assert.IsNotNull(tags);
		}
	}
}
