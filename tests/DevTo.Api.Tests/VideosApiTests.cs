using Forem.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace Forem.Api.Tests
{
	[TestClass]
	public class VideosApiTests : TestBase
	{
		[TestMethod]
		public async Task GetVideos()
		{
			var videosService = new VideosService(BaseUri, HttpClient);
			var videos = await videosService.GetVideosAsync();
			Assert.IsTrue(videos.Any());
		}

		[TestMethod]
		public async Task GetVideosWithPagination()
		{
			var videosService = new VideosService(BaseUri, HttpClient);
			var firstPageOfVideos = await videosService.GetVideosAsync(1, 2);
			var secondPageOfVideos = await videosService.GetVideosAsync(2, 2);
			Assert.IsTrue(firstPageOfVideos.Any());
			Assert.IsTrue(secondPageOfVideos.Any());
			Assert.AreNotEqual(firstPageOfVideos.First().VideoId, secondPageOfVideos.First().VideoId);
		}
	}
}
