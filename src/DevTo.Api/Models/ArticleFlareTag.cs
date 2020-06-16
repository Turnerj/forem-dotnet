using Newtonsoft.Json;

namespace Forem.Api.Models
{
	public class ArticleFlareTag
	{
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("bg_color_hex")]
		public string BgColor { get; set; }
		[JsonProperty("text_color_hex")]
		public string TextColor { get; set; }
	}
}
