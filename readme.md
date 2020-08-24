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

### Installation

To install the library run the below on Nuget Manager Console:

`Install-Package Forem.Api -Version 0.4.0`	

## Usage

-For Some of the methods, DEV API key `apiKey`  is required is be passed for authenticate the you as a user. 
To Obtain one, check the authentication section [GET API KEY](https://docs.dev.to/api/#section/Authentication)

-Using DI, Add the service to the container just by doing the below:
`services.AddForemApi(new Uri("https://dev.to/"));`

-Configure your `HttpClient` DI by adding the below snippet to your `startup.cs` file (or wherever you're configuring your DI things):

```csharp
	services.AddHttpClient();
	services.AddTransient(provider =>
	{
		return provider.GetRequiredService<IHttpClientFactory>().CreateClient(string.Empty);
	});
```

Havng all this setup, then you're good to go!!


## Snippets

### Articles

```csharp
    using Forem.Api;

	
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticlesService _articlesService;
        private readonly ITagsService _tagsService;

        //Without Dependency Injection - global
        ArticlesService articlesService = new ArticlesService(new Uri("https://dev.to/"), new HttpClient());

        //With Dependency Injection
        public ArticleController(IArticlesService articlesService, ITagsService tagsService)
        {
            _articlesService = articlesService;
            _tagsService = tagsService;
        }

```

To get all articles you simply just call `GetArticlesAsync` passing optional params `page` and `perPage` with default values `1` & `30` respectively.

```csharp
	[HttpGet("all")]
        public async Task<IActionResult> GetAllArticles(int page, int itemPerPage)
        {
            //Without DI - local
            //var articlesService = new ArticlesService(new Uri("https://dev.to/"), new HttpClient());
           
            var articles = await articlesService.GetArticlesAsync();

            articles = await _articlesService.GetArticlesAsync(page, itemPerPage);
            
            return Ok(articles);
        }

```

Feel free to check out other methods/endpoints [Aticles Doc](https://docs.dev.to/api/#operation/getArticles)

