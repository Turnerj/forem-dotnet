# Forem API for .NET
API interface for the blogging platform formerly [dev.to (DEV)](https://dev.to/) now [Forem](https://dev.to/devteam/for-empowering-community-2k6h) 

[![AppVeyor](https://img.shields.io/appveyor/ci/Turnerj/devto-dotnet/master.svg)](https://ci.appveyor.com/project/Turnerj/devto-dotnet)
[![Codecov](https://img.shields.io/codecov/c/github/turnerj/devto-dotnet/master.svg)](https://codecov.io/gh/turnerj/devto-dotnet)
[![NuGet](https://img.shields.io/nuget/v/DevTo.Api.svg)](https://www.nuget.org/packages/DevTo.Api)

## Supports
- Create article
- Update article
- Get user articles (these are articles related to the API key)
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

services.AddForemApi(new Uri("https://dev.to/"));
```

```csharp
using Forem.Api;

public class MyClass
{
	private IArticlesApi ArticlesApi { get; }
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
using Forem.Api;
using System.Net.Http;

var articlesService = new ArticlesService(new Uri("https://dev.to/"), new HttpClient());
var tagsService = new TagsService(new Uri("https://dev.to/"), new HttpClient());

var articles = await articlesService.GetArticlesAsync();
```