using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace DevTo.Api.Serialization
{
	public class MultiTypeTagConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException("Unnecessary because this is read-only");
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.StartArray)
			{
				//Move from start of array to first element
				reader.Read();

				var tags = new List<string>();

				while (reader.TokenType != JsonToken.EndArray)
				{
					var tag = reader.Value.ToString().Trim();
					tags.Add(tag);

					//Move forward to next token
					reader.Read();
				}

				return tags as IEnumerable<string>;
			}
			else if (reader.TokenType == JsonToken.String)
			{
				return (reader.Value as string).Split(new[] { ',' }).Select(t => t.Trim());
			}
			else
			{
				throw new InvalidOperationException($"Unexpected token type {reader.TokenType}");
			}
		}

		public override bool CanWrite => false;

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(IEnumerable<string>);
		}
	}
}
