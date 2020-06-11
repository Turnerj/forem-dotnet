using DevTo.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevTo.Api
{
	public interface ICommentsApi
	{
		/// <summary>
		/// Retrieves all comments belonging to an article as threaded conversations.
		/// </summary>
		/// <param name="articleId">The article ID.</param>
		/// <returns></returns>
		Task<IEnumerable<Comment>> GetCommentsByArticleAsync(int articleId);
		/// <summary>
		/// Retrieves a comment as well as his descendants comments.
		/// </summary>
		/// <param name="id">The comment ID.</param>
		/// <returns></returns>
		Task<Comment> GetCommentAsync(string id);
	}
}
