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
			services.AddTransient<IArticleApi, ArticleService>(sp =>
				new ArticleService(baseUri, sp.GetService<HttpClient>())
			);

			services.AddTransient<ITagsApi, TagService>(sp =>
				new TagService(baseUri, sp.GetService<HttpClient>())
			);
		}
	}
}