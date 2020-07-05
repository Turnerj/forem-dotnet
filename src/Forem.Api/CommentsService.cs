using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Forem.Api.Models;

namespace Forem.Api
{
	public class CommentsService : ApiService, ICommentsService
	{
		public CommentsService(Uri baseUri, HttpClient httpClient) : base(baseUri, httpClient) { }

		public Task<IEnumerable<Comment>> GetCommentsByArticleAsync(int articleId)
			=> GetAsync<IEnumerable<Comment>>("/api/comments", new Dictionary<string, object>
				{
				  { "a_id", articleId },
				});

		public Task<Comment> GetCommentAsync(string id) => GetAsync<Comment>($"/api/comments/{id}");
	}
}
