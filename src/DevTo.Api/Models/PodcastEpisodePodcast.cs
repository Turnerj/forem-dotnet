using Newtonsoft.Json;

namespace Forem.Api.Models
{
	public class PodcastEpisodePodcast
	{
		[JsonProperty("title")]
		public string Title { get; set; }
		[JsonProperty("slug")]
		public string Slug { get; set; }
		[JsonProperty("image_url")]
		public string ImageUrl { get; set; }
	}
}
