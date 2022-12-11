using Newtonsoft.Json;

namespace Forem.Api.Models
{
	public class UserArticle : Article
	{
		[JsonProperty("page_views_count")]
		public int NumberOfPageViews { get; set; }
		[JsonProperty("published")]
		public bool Published { get; set; }
		[JsonProperty("body_markdown")]
		public string BodyMarkdown { get; set; }

	}
}
