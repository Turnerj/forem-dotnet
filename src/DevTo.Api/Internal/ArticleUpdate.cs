using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Forem.Api.Internal
{
	internal class ArticleUpdate
	{
		[JsonProperty("article")]
		public ArticlePayload Article { get; set; }

		public class ArticlePayload
		{
			[JsonProperty("body_markdown")]
			public string Markdown { get; set; }
		}
	}
}
