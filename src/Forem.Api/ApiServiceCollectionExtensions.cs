using Forem.Api;
using System;
using System.Net.Http;

namespace Microsoft.Extensions.DependencyInjection
{
	public static class ApiServiceCollectionExtensions
	{
		public static void AddForemApi(this IServiceCollection services, Uri baseUri)
		{
			services.AddTransient<IArticlesService, ArticlesService>(sp =>
				new ArticlesService(baseUri, sp.GetService<HttpClient>())
			);

			services.AddTransient<ICommentsService, CommentsService>(sp =>
				new CommentsService(baseUri, sp.GetService<HttpClient>())
			);

			services.AddTransient<IFollowersService, FollowersService>(sp =>
				new FollowersService(baseUri, sp.GetService<HttpClient>())
			);

			services.AddTransient<IListingsService, ListingsService>(sp =>
				new ListingsService(baseUri, sp.GetService<HttpClient>())
			);

			services.AddTransient<IPodcastEpisodesService, PodcastEpisodesService>(sp =>
				new PodcastEpisodesService(baseUri, sp.GetService<HttpClient>())
			);

			services.AddTransient<ITagsService, TagsService>(sp =>
				new TagsService(baseUri, sp.GetService<HttpClient>())
			);

			services.AddTransient<IUsersService, UsersService>(sp =>
				new UsersService(baseUri, sp.GetService<HttpClient>())
			);

			services.AddTransient<IVideosService, VideosService>(sp =>
				new VideosService(baseUri, sp.GetService<HttpClient>())
			);

			services.AddTransient<IWebhooksService, WebhooksService>(sp =>
				new WebhooksService(baseUri, sp.GetService<HttpClient>())
			);
		}
	}
}