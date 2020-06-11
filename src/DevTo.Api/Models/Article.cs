using System;
using System.Collections.Generic;
using System.Text;
using Forem.Api.Serialization;
using Newtonsoft.Json;

namespace Forem.Api.Models
{
	public class Article
	{
		[JsonProperty("id")]
		public int ArticleId { get; set; }
		[JsonProperty("title")]
		public string Title { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("cover_image")]
		public Uri CoverImage { get; set; }
		[JsonProperty("social_image")]
		public Uri SocialImage { get; set; }
		[JsonProperty("created_at")]
		public DateTime CreatedAt { get; set; }
		[JsonProperty("published_at")]
		public DateTime PublishedAt { get; set; }
		[JsonProperty("edited_at")]
		public DateTime? EditedAt { get; set; }
		[JsonProperty("tag_list")]
		[JsonConverter(typeof(MultiTypeTagConverter))]
		public IEnumerable<string> TagList { get; set; }

		[JsonProperty("slug")]
		public string Slug { get; set; }
		[JsonProperty("path")]
		public string Path { get; set; }
		[JsonProperty("canonical_url")]
		public Uri CanonicalUrl { get; set; }
		[JsonProperty("article_url")]
		public Uri ArticleUrl { get; set; }

		[JsonProperty("comments_count")]
		public int NumberOfComments { get; set; }
		[JsonProperty("positive_reactions_count")]
		public int NumberOfReactions { get; set; }

		[JsonProperty("body_html")]
		public string BodyHtml { get; set; }

		[JsonProperty("user")]
		public User User { get; set; }
		[JsonProperty("organization")]
		public ArticleOrganisation Organization { get; set; }
	}
}
