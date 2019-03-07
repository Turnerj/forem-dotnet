# Dev.to API for .NET
A basic read-only interface to [dev.to](https://dev.to/)

[![AppVeyor](https://img.shields.io/appveyor/ci/Turnerj/devto-dotnet/master.svg)](https://ci.appveyor.com/project/Turnerj/devto-dotnet)
[![Codecov](https://img.shields.io/codecov/c/github/turnerj/devto-dotnet/master.svg)](https://codecov.io/gh/turnerj/devto-dotnet)
[![NuGet](https://img.shields.io/nuget/v/DevTo.Api.svg)](https://www.nuget.org/packages/DevTo.Api)

## Supports
- Recent articles (inc. pagination)
- Recent articles by tag (inc. pagination)
- Get Article (including article body)
- Get Tags (inc. pagination)

## Getting Started

### With DI

```csharp
using Microsoft.Extensions.DependencyInjection;

services.AddDevToApi(new Uri("https://dev.to/"));
```

```csharp
using DevTo.Api;

public class MyClass
{
	private IArticleApi ArticleApi { get; }
	private ITagsApi TagsApi { get; }

	public MyClass(IArticleApi articleApi, ITagsApi tagsApi)
	{
		ArticleApi = articleApi;
		TagsApi = tagsApi;
	}

	public async Task DoWork()
	{
		var articles = await ArticlesApi.GetRecentArticlesAsync();
		
		// Your code here...
	}
}
```

### Without DI

```csharp
using DevTo.Api;
using System.Net.Http;

var articleService = new ArticleService(new Uri("https://dev.to/"), new HttpClient());
var tagService = new TagService(new Uri("https://dev.to/"), new HttpClient());

var articles = await articleService.GetRecentArticlesAsync();
```