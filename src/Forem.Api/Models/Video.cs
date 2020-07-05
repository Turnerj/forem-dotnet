using Newtonsoft.Json;

namespace Forem.Api.Models
{
	public class Video
	{
		[JsonProperty("id")]
		public int VideoId { get; set; }
		[JsonProperty("title")]
		public string Title { get; set; }
		[JsonProperty("path")]
		public string Path { get; set; }
		[JsonProperty("cloudinary_video_url")]
		public string CloudinaryUrl { get; set; }
		[JsonProperty("user_id")]
		public int UserId { get; set; }
		[JsonProperty("video_duration_in_minutes")]
		public string Duration { get; set; }
		[JsonProperty("user.name")]
		public string UserName { get; set; }
	}
}
