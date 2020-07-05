using Newtonsoft.Json;
using System;

namespace Forem.Api.Models
{
	public class Follower
	{
		[JsonProperty("id")]
		public int FollowerId { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("path")]
		public string Path { get; set; }
		[JsonProperty("username")]
		public string Username { get; set; }
		[JsonProperty("profile_image")]
		public Uri ProfileImage { get; set; }
	}
}
