using Forem.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forem.Api
{
	public interface ITagsApi
	{
		/// <summary>
		/// Retrieve all tags, ordered by popularity.
		/// </summary>
		/// <param name="page">The page number for the tags.</param>
		/// <returns></returns>
		Task<IEnumerable<Tag>> GetTagsAsync(int page = 1);
	}
}
