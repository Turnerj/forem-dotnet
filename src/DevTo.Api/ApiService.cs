using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DevTo.Api
{
	public abstract class ApiService
	{
		protected Uri BaseUri { get; }
		protected HttpClient HttpClient { get; }

		public ApiService(Uri baseUri, HttpClient httpClient)
		{
			BaseUri = baseUri;
			HttpClient = httpClient;
		}

		protected async Task<TResponse> GetAsync<TResponse>(string path, object parameters = null)
		{
			var uri = BuildRequestUri(path, parameters);
			using (var response = await HttpClient.GetAsync(uri))
			{
				var responseJson = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<TResponse>(responseJson);
			}
		}

		private Uri BuildRequestUri(string path, object parameters)
		{
			var builder = new UriBuilder(BaseUri)
			{
				Path = path
			};

			if (parameters != null)
			{
				IDictionary<string, object> queryString;
				if (parameters is IDictionary<string, object> paramDict)
				{
					queryString = paramDict;
				}
				else
				{
					queryString = new Dictionary<string, object>();
					var properties = parameters.GetType().GetProperties();
					foreach (var property in properties)
					{
						var value = property.GetValue(parameters);
						queryString.Add(property.Name, value);
					}
				}

				builder.Query = string.Join("&", queryString.Select(kp =>
					Uri.EscapeDataString(kp.Key) + "=" + Uri.EscapeDataString(kp.Value?.ToString() ?? string.Empty)
				));
			}

			return builder.Uri;
		}
	}
}
