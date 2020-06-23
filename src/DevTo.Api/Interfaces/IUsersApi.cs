using Forem.Api.Models;
using System.Threading.Tasks;

namespace Forem.Api.Interfaces
{
	public interface IUsersApi
	{
		/// <summary>
		/// Retrieve a single user by id.
		/// </summary>
		/// <param name="id">Id of the user.</param>
		/// <returns></returns>
		Task<User> GetUserAsync(int id);
		/// <summary>
		/// Retrieve a single user by the user's username.
		/// </summary>
		/// <param name="username">Username of the user.</param>
		/// <returns></returns>
		Task<User> GetUserAsync(string username);
		/// <summary>
		/// Retrieve information about the authenticated user.
		/// </summary>
		/// <returns></returns>
		Task<User> GetAuthenticatedUserAsync(string apiKey);
	}
}
