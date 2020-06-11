using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DevTo.Api.Models;

namespace DevTo.Api
{
	public class CommentsService : ApiService, ICommentsApi
	{
		public CommentsService(Uri baseUri, HttpClient httpClient) : base(baseUri, httpClient) { }

		public Task<IEnumerable<Comment>> GetCommentsByArticleAsync(int articleId)
		{
			return GetAsync<IEnumerable<Comment>>("/api/comments", new Dictionary<string, object>
			{
			  { "a_id", articleId },
			});
		}

		public Task<Comment> GetCommentAsync(string id)
		{
			return GetAsync<Comment>($"/api/comments/{id}");
		}
	}
}
