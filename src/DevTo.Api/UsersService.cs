using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Forem.Api.Models;

namespace Forem.Api
{
	public class UsersService : ApiService, IUsersApi
	{
		public UsersService(Uri baseUri, HttpClient httpClient) : base(baseUri, httpClient) { }

		public Task<User> GetUserAsync(int id) => GetAsync<User>($"/api/users/{id}");

		public Task<User> GetUserAsync(string username)
			=> GetAsync<User>("/api/users/by_username", new Dictionary<string, object>
				{
				  { "url", username },
				});

		public Task<User> GetAuthenticatedUserAsync(string apiKey) => GetAsync<User>($"/api/users/me", null, apiKey);
	}
}
