using Newtonsoft.Json;

namespace Forem.Api.Models
{
	public class PodcastEpisode
	{
		[JsonProperty("id")]
		public int PodcastEpisodeId { get; set; }
		[JsonProperty("path")]
		public string Path { get; set; }
		[JsonProperty("image_url")]
		public string ImageUrl { get; set; }
		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("podcast")]
		public PodcastEpisodePodcast Podcast { get; set; }
	}
}
