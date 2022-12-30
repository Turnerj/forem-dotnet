using System;
using System.Collections.Generic;
using System.Text;
using Forem.Api.Serialization;
using Newtonsoft.Json;

namespace Forem.Api.Models
{

	public class Article
	{

		[JsonProperty("type_of")]
		public string TypeOf { get; set; }
		[JsonProperty("id")]
		public int ArticleId { get; set; }
		[JsonProperty("title")]
		public string Title { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("cover_image")]
		public Uri CoverImage { get; set; }

		[JsonProperty("readable_publish_date")]
		public string ReadablePublishDate { get; set; }

		[JsonProperty("social_image")]
		public Uri SocialImage { get; set; }
		
		[JsonProperty("tags")]
		public string Tags { get; set; }

		[JsonProperty("tag_list")]
		[JsonConverter(typeof(MultiTypeTagConverter))]
		public IEnumerable<string> TagList { get; set; }

		[JsonProperty("slug")]
		public string Slug { get; set; }
		[JsonProperty("path")]
		public string Path { get; set; }
		[JsonProperty("canonical_url")]
		public Uri CanonicalUrl { get; set; }
		[JsonProperty("url")]
		public Uri ArticleUrl { get; set; }

		[JsonProperty("comments_count")]
		public int NumberOfComments { get; set; }
		[JsonProperty("positive_reactions_count")]
		public int NumberOfReactions { get; set; }

		[JsonProperty("public_reactions_count")]
		public int NumberOfPublicReactions { get; set; }

		[JsonProperty("collection_id")]
		public int? CollectionId { get; set; }

		[JsonProperty("created_at")]
		public DateTime CreatedAt { get; set; }
		
		[JsonProperty("edited_at")]
		public DateTime? EditedAt { get; set; }

		[JsonProperty("crossposted_at")]
		public DateTime CrossPostedAt { get; set; }

		[JsonProperty("published_at")]
		public DateTime PublishedAt { get; set; }
		[JsonProperty("last_comment_at")]
		public DateTime LastCommentAt { get; set; }

		[JsonProperty("published_timestamp")]
		public DateTime PublishedTimestamp { get; set; }
		
		[JsonProperty("reading_time_minutes")]
		public int ReadingTime { get; set; }

		[JsonProperty("user")]
		public User User { get; set; }
		[JsonProperty("organization")]
		public Organisation Organization { get; set; }

		[JsonProperty("flare_tag")]
		public FlareTag FlareTag { get; set; }
	}
}
