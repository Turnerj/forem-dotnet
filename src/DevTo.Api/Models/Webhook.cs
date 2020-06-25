using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Forem.Api.Models
{
	public class Webhook
	{
		[JsonProperty("id")]
		public string WebhookId { get; set; }
		[JsonProperty("source")]
		public string Source { get; set; }
		[JsonProperty("target_url")]
		public Uri TargetUrl { get; set; }
		[JsonProperty("events")]
		public IEnumerable<string> Events { get; set; }
		[JsonProperty("created_at")]
		public DateTime CreatedAt { get; set; }
		[JsonProperty("user")]
		public User User { get; set; }
	}
}
