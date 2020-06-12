using Microsoft.VisualStudio.TestTools.UnitTesting;
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
			Assert.IsNotNull(podcastEpisodes);
		}

		[TestMethod]
		public async Task GetPodcastEpisodesByUser()
		{
			var podcastEpisodesService = new PodcastEpisodesService(BaseUri, HttpClient);
			var podcastEpisodes = await podcastEpisodesService.GetPodcastEpisodesAsync("devdiscuss");
			Assert.IsNotNull(podcastEpisodes);
		}
	}
}
