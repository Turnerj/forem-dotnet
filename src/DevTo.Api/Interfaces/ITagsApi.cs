using Forem.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forem.Api.Interfaces
{
	public interface ITagsApi
	{
		/// <summary>
		/// Retrieve all tags, ordered by popularity.
		/// </summary>
		/// <param name="page">The page number for the tags.</param>
		/// <param name="perPage">Page size (the number of items to return per page).</param>
		/// <returns></returns>
		Task<IEnumerable<Tag>> GetTagsAsync(int page, int perPage);
	}
}
