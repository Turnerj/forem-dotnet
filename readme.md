# Forem API for .NET
API interface for [Forem](https://www.forem.com/) apps. Forem is the platform which powers [DEV](https://dev.to) and other online communities.

[![AppVeyor](https://img.shields.io/appveyor/ci/Turnerj/forem-dotnet/master.svg)](https://ci.appveyor.com/project/Turnerj/forem-dotnet)
[![Codecov](https://img.shields.io/codecov/c/github/turnerj/forem-dotnet/master.svg)](https://codecov.io/gh/turnerj/forem-dotnet)
[![NuGet](https://img.shields.io/nuget/v/Forem.Api.svg)](https://www.nuget.org/packages/Forem.Api)

## API Support

We attempt to support all the API endpoints per the [Forem/DEV API](https://docs.dev.to/api/), which includes:

- Articles
- Users
- Podcasts
- Videos

Where available, the library supports pagination and page size controls.
If there is an API endpoint that isn't currently supported, feel free to open an issue or create a PR.

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
	private IArticlesService ArticlesService { get; }
	private ITagsService TagsService { get; }

	public MyClass(IArticlesService articlesService, ITagsService tagsService)
	{
		ArticlesService = articlesService;
		TagsService = tagsService;
	}

	public async Task DoWork()
	{
		var articles = await ArticlesService.GetArticlesAsync();
		
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
