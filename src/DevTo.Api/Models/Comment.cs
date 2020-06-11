using System.Collections.Generic;
using Newtonsoft.Json;

namespace Forem.Api.Models
{
	public class Comment
	{
		[JsonProperty("id")]
		public string ComentId { get; set; }
		[JsonProperty("body_html")]
		public string BodyHTML { get; set; }
		[JsonProperty("user")]
		public User User { get; set; }

		[JsonProperty("children")]
		public IEnumerable<Comment> Children { get; set; }
	}
}
