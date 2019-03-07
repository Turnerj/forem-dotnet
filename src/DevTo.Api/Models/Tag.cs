using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevTo.Api.Models
{
	public class Tag
	{
		[JsonProperty("id")]
		public int TagId { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("bg_color_hex")]
		public string BackgroundColour { get; set; }
		[JsonProperty("text_color_hex")]
		public string ForegroundColour { get; set; }
	}
}
