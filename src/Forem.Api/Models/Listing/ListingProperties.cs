using System;
using System.Collections.Generic;

namespace Forem.Api.Models.Listing
{
	public class ListingProperties
	{
		public string Title { get; set; }
		public string BodyMarkdown { get; set; }
		public ListingCategory? Category { get; set; } = null;
		public IEnumerable<string> Tags { get; set; } = null;
		public DateTime? ExpiresAt { get; set; } = null;
		public bool? ContactViaConnect { get; set; } = null;
		public string Location { get; set; }
		public long? OrganizationId { get; set; } = null;
	}
}
