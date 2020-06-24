using Forem.Api.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Forem.Api
{
	public abstract class ApiService
	{
		protected Uri BaseUri { get; }
		protected HttpClient HttpClient { get; }

		protected ApiService(Uri baseUri, HttpClient httpClient)
		{
			BaseUri = baseUri;
			HttpClient = httpClient;
		}

		protected async Task<TResponse> GetAsync<TResponse>(string path, object parameters = null, string apiKey = null)
		{
			var uri = BuildRequestUri(path, parameters);
			var message = new HttpRequestMessage(HttpMethod.Get, uri);

			if (apiKey != default)
			{
				message.Headers.Add("api-key", apiKey);
			}

			using (var response = await HttpClient.SendAsync(message))
			{
				var responseJson = await response.Content.ReadAsStringAsync();

				if (response.IsSuccessStatusCode)
				{
					return JsonConvert.DeserializeObject<TResponse>(responseJson);
				}
				else
				{
					string error;
					int statusCode;

					try
					{
						var rawConversion = JsonConvert.DeserializeObject(responseJson) as JObject;
						error = rawConversion["error"].ToString();
						statusCode = (int)rawConversion["status"];
					}
					catch
					{
						throw new ApiException(response.StatusCode);
					}

					throw new ApiException(statusCode, error);
				}
			}
		}

		private async Task<TResponse> SendAsync<TResponse>(string path, object body, string apiKey, HttpMethod method)
		{
			var uri = BuildRequestUri(path, null);
			var message = new HttpRequestMessage(method, uri);
			message.Headers.Add("api-key", apiKey);
			message.Content = new StringContent(JsonConvert.SerializeObject(body));

			using (var response = await HttpClient.SendAsync(message))
			{
				var responseJson = await response.Content.ReadAsStringAsync();

				if (response.IsSuccessStatusCode)
				{
					return JsonConvert.DeserializeObject<TResponse>(responseJson);
				}
				else
				{
					string error;
					int statusCode;

					try
					{
						var rawConversion = JsonConvert.DeserializeObject(responseJson) as JObject;
						error = rawConversion["error"].ToString();
						statusCode = (int)rawConversion["status"];
					}
					catch
					{
						throw new ApiException(response.StatusCode);
					}

					throw new ApiException(statusCode, error);
				}
			}
		}

		protected async Task<TResponse> PutAsync<TResponse>(string path, object body, string apiKey)
			=> await SendAsync<TResponse>(path, body, apiKey, HttpMethod.Put);

		protected async Task<TResponse> PostAsync<TResponse>(string path, object body, string apiKey)
			=> await SendAsync<TResponse>(path, body, apiKey, HttpMethod.Post);

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
