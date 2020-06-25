using Forem.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace Forem.Api.Tests
{
	[TestClass]
	public class PodcastEpisodesApiTests : TestBase
	{
		[TestMethod]
		public async Task GetPodcastEpisodes()
		{
			var podcastEpisodesService = new PodcastEpisodesService(BaseUri, HttpClient);
			var podcastEpisodes = await podcastEpisodesService.GetPodcastEpisodesAsync();
			Assert.IsTrue(podcastEpisodes.Any());
		}

		[TestMethod]
		public async Task GetPodcastEpisodesByUser()
		{
			var podcastEpisodesService = new PodcastEpisodesService(BaseUri, HttpClient);
			var podcastEpisodes = await podcastEpisodesService.GetPodcastEpisodesAsync("devdiscuss");
			Assert.IsNotNull(podcastEpisodes);
		}

		[TestMethod]
		public async Task GetPodcastEpisodesWithPagination()
		{
			var podcastEpisodesService = new PodcastEpisodesService(BaseUri, HttpClient);
			var firstPageOfPodcastEpisodes = await podcastEpisodesService.GetPodcastEpisodesAsync("devdiscuss", 1, 2);
			var secondPageOfPodcastEpisodes = await podcastEpisodesService.GetPodcastEpisodesAsync("devdiscuss", 2, 2);
			Assert.IsTrue(firstPageOfPodcastEpisodes.Any());
			Assert.IsTrue(secondPageOfPodcastEpisodes.Any());
			Assert.AreNotEqual(firstPageOfPodcastEpisodes.First().PodcastEpisodeId, secondPageOfPodcastEpisodes.First().PodcastEpisodeId);
		}
	}
}

