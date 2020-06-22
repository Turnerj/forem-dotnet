using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Forem.Api.Models.Listing
{
	public class CompleteListing : Listing
	{
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("cover_image")]
		public Uri CoverImage { get; set; }
		[JsonProperty("social_image")]
		public Uri SocialImage { get; set; }
		[JsonProperty("readable_publish_date")]
		public string ReadablePublishDate { get; set; }
		[JsonProperty("path")]
		public string Path { get; set; }
		[JsonProperty("url")]
		public Uri Url { get; set; }
		[JsonProperty("canonical_url")]
		public Uri CanonicalUrl { get; set; }
		[JsonProperty("comments_count")]
		public int NumberOfComments { get; set; }
		[JsonProperty("public_reactions_count")]
		public int NumberOfReactions { get; set; }
		[JsonProperty("created_at")]
		public DateTime CreatedAt { get; set; }
		[JsonProperty("published_at")]
		public DateTime PublishedAt { get; set; }
		[JsonProperty("edited_at")]
		public DateTime EditedAt { get; set; }
		[JsonProperty("crossposted_at")]
		public DateTime CrosspostedAt { get; set; }
		[JsonProperty("last_comment_at")]
		public DateTime LastCommentAt { get; set; }
		[JsonProperty("published_timestamp")]
		public DateTime PublishedTimestamp { get; set; }		
		[JsonProperty("body_html")]
		public string BodyHtml { get; set; }
		[JsonProperty("flare_tag")]
		public FlareTag FlareTag { get; set; }
	}
}
