using DevTo.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevTo.Api
{
	public interface ITagsApi
	{
		Task<IEnumerable<Tag>> GetTagsAsync(int page = 1);
	}
}
