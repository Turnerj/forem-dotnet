using DevTo.Api;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
	public static class ApiServiceCollectionExtensions
	{
		public static void AddDevToApi(this IServiceCollection services, Uri baseUri)
		{
			services.AddTransient<IArticlesApi, ArticlesService>(sp =>
				new ArticlesService(baseUri, sp.GetService<HttpClient>())
			);

			services.AddTransient<ITagsApi, TagsService>(sp =>
				new TagsService(baseUri, sp.GetService<HttpClient>())
			);
		}
	}
}