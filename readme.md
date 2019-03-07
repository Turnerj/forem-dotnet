# Dev.to API for .NET

This is a fairly basic read-only library for the blogging platform [dev.to](https://dev.to/) based on the "V0" API.
The API this is linked isn't officially released yet so may change in the future.

Currently supports:
- Retrieve recent articles (optionally by tag)
- Retrieve full article (by id)
- Retrieve tags

## Getting Started

You can use the `AddDevToApi` service collection extension if you are using dependency injection.

```csharp
services.AddDevToApi(new Uri("https://dev.to/"));
```

In your class constructor, reference the `IArticleApi` or `ITagsApi`.

Without dependency injection, you need to reference `ArticleService` and `TagService`.