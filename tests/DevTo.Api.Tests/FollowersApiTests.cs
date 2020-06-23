using Forem.Api.Models;
using Forem.Api.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Forem.Api.Tests
{
	[TestClass]
	public class FollowersApiTests : TestBase
	{
		[TestMethod, ExpectedException(typeof(ApiException))]
		public async Task GetUserFollowers_WithInvalidApiKeyThrowsException()
		{
			var followersService = new FollowersService(BaseUri, HttpClient);
			await followersService.GetUserFollowersAsync("NotARealApiKey");
		}
	}
}
