using Forem.Api.Models;
using Forem.Api.Models.Listing;
using Forem.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace Forem.Api.Tests
{
	[TestClass]
	public class ListingsApiTests : TestBase
	{
		[TestMethod, ExpectedException(typeof(ApiException))]
		public async Task CreateListing_WithInvalidApiKeyThrowsException()
		{
			var listingService = new ListingsService(BaseUri, HttpClient);

			var listingProperties = new ListingProperties();
			listingProperties.Title = "Test";
			listingProperties.BodyMarkdown = "";
			listingProperties.Category = ListingCategory.Mentors;

			await listingService.CreateListingAsync("NotARealApiKey", listingProperties, ListingAction.Draft);
		}

		[TestMethod, ExpectedException(typeof(ApiException))]
		public async Task UpdateListing_WithInvalidApiKeyThrowsException()
		{
			var listingProperties = new ListingProperties();
			listingProperties.Title = "Test";
			listingProperties.BodyMarkdown = "";
			listingProperties.Category = ListingCategory.Mentors;

			var listingService = new ListingsService(BaseUri, HttpClient);
			await listingService.UpdateListingAsync("NotARealApiKey", 1635, ListingAction.Update, listingProperties);
		}

		[TestMethod, ExpectedException(typeof(ApiException))]
		public async Task UpdateListingBump_WithInvalidApiKeyThrowsException()
		{
			var listingService = new ListingsService(BaseUri, HttpClient);
			await listingService.UpdateListingAsync("NotARealApiKey", 1635, ListingAction.Bump, null);
		}

		[TestMethod]
		public async Task GetListings()
		{
			var listingService = new ListingsService(BaseUri, HttpClient);
			var listings = await listingService.GetListingsAsync();
			Assert.IsTrue(listings.Any());
		}
		
		[TestMethod]
		public async Task GetListingsWithPagination()
		{
			var listingService = new ListingsService(BaseUri, HttpClient);
			var firstPageOfListings = await listingService.GetListingsAsync(1);
			var secondPageOfListings = await listingService.GetListingsAsync(2);
			Assert.IsTrue(firstPageOfListings.Any());
			Assert.IsTrue(secondPageOfListings.Any());
			Assert.AreNotEqual(firstPageOfListings.First().ListingId, secondPageOfListings.First().ListingId);
		}

		[TestMethod]
		public async Task GetListingsByCategory()
		{
			var listingService = new ListingsService(BaseUri, HttpClient);
			var listings = await listingService.GetListingsByCategoryAsync(ListingCategory.Education);
			Assert.IsNotNull(listings);
			Assert.IsTrue(listings.All(l => l.Category == ListingCategory.Education));
		}

		[TestMethod]
		public async Task GetListing()
		{
			var listingService = new ListingsService(BaseUri, HttpClient);
			var listing = await listingService.GetListingAsync(4008);
			Assert.IsNotNull(listing);
		}
	}
}
