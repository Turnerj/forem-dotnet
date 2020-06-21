using System.Collections.Generic;
using Newtonsoft.Json;

namespace Forem.Api.Models.Listing
{
	public class Listing
	{
		[JsonProperty("id")]
		public long ListingId { get; set; }
		[JsonProperty("title")]
		public string Title { get; set; }
		[JsonProperty("slug")]
		public string Slug { get; set; }
		[JsonProperty("body_markdown")]
		public string BodyMarkdown { get; set; }
		[JsonProperty("category")]
		public ListingCategory Category { get; set; }
		[JsonProperty("processed_html")]
		public string ProcessedHtml { get; set; }
		[JsonProperty("published")]
		public bool Published { get; set; }

		[JsonProperty("tags")]
		public IEnumerable<string> Tags { get; set; }
		[JsonProperty("user")]
		public User User { get; set; }
		[JsonProperty("organization")]
		public Organisation Organization { get; set; }
	}
}
