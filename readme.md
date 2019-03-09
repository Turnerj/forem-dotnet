# Dev.to API for .NET
A basic read-only interface to [dev.to](https://dev.to/)

[![AppVeyor](https://img.shields.io/appveyor/ci/Turnerj/devto-dotnet/master.svg)](https://ci.appveyor.com/project/Turnerj/devto-dotnet)
[![Codecov](https://img.shields.io/codecov/c/github/turnerj/devto-dotnet/master.svg)](https://codecov.io/gh/turnerj/devto-dotnet)
[![NuGet](https://img.shields.io/nuget/v/DevTo.Api.svg)](https://www.nuget.org/packages/DevTo.Api)

## Supports
- Get articles
- Get articles by tag
- Get articles by user
- Get article (including article body)
- Get tags

Where available, supports basic pagination to request additional data.

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
	private IArticleApi ArticlesApi { get; }
	private ITagsApi TagsApi { get; }

	public MyClass(IArticlesApi articlesApi, ITagsApi tagsApi)
	{
		ArticlesApi = articlesApi;
		TagsApi = tagsApi;
	}

	public async Task DoWork()
	{
		var articles = await ArticlesApi.GetArticlesAsync();
		
		// Your code here...
	}
}
```

### Without DI

```csharp
using DevTo.Api;
using System.Net.Http;

var articlesService = new ArticlesService(new Uri("https://dev.to/"), new HttpClient());
var tagsService = new TagsService(new Uri("https://dev.to/"), new HttpClient());

var articles = await articlesService.GetArticlesAsync();
```