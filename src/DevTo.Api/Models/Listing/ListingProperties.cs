using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Forem.Api.Models.Listing
{
	public class ListingProperties
	{
		[JsonProperty("title")]
		public string Title { get; set; } = null;
		[JsonProperty("body_markdown")]
		public string BodyMarkdown { get; set; } = null;
		[JsonProperty("category")]
		public ListingCategory? Category { get; set; } = null;
		[JsonProperty("tags")]
		public IEnumerable<string> Tags { get; set; } = null;
		[JsonProperty("expires_at")]
		public DateTime? ExpiresAt { get; set; } = null;
		[JsonProperty("contact_via_connect")]
		public bool? ContactViaConnect { get; set; } = null;
		[JsonProperty("location")]
		public string Location { get; set; } = null;
		[JsonProperty("organization_id")]
		public long? OrganizationId { get; set; } = null;
	}
}
