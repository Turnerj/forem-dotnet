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
	}
}
