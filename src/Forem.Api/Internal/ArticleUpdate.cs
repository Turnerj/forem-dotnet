using System;
using System.Collections.Generic;
using System.Text;
using Forem.Api.Serialization;
using Newtonsoft.Json;

namespace Forem.Api.Internal
{
	internal class ArticleUpdate
	{
		[JsonProperty("article")]
		public ArticlePayload Article { get; set; }
	}
	public class ArticlePayload
	{
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		/// True to create a published article, false otherwise. Defaults to false
		/// </summary>
		[JsonProperty("published")]
		public bool Published { get; set; }

		/// <summary>
		/// The body of the article. <br/>
		/// It can contain an optional front matter
		/// </summary>
		[JsonProperty("body_markdown")]
		public string Markdown { get; set; }

		[JsonProperty("tags")]
		[JsonConverter(typeof(MultiTypeTagConverter))]
		public IEnumerable<string> Tags { get; set; }

		/// <summary>
		/// Article series name. <br />
		/// All articles belonging to the same series need to have the same name in this parameter.
		/// </summary>
		[JsonProperty("series")]
		public string Series { get; set; }
	}
}
