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
		public bool BodyMarkdown { get; set; }

		[JsonProperty("flare_tag")]
		public ArticleFlareTag FlareTag { get; set; }
	}
}
