using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forem.Api.Models
{
	public class ArticleAuthor
	{
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("username")]
		public string Username { get; set; }

		[JsonProperty("twitter_username")]
		public string TwitterUsername { get; set; }
		[JsonProperty("github_username")]
		public string GitHubUsername { get; set; }
		[JsonProperty("website_url")]
		public Uri WebsiteUrl { get; set; }

		[JsonProperty("profile_image")]
		public Uri ProfileImageLarge { get; set; }
		[JsonProperty("profile_image_90")]
		public Uri ProfileImageSmall { get; set; }
	}
}
