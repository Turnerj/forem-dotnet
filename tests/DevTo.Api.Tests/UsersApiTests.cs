using Forem.Api.Models;
using Forem.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Forem.Api.Tests
{
	[TestClass]
	public class UsersApiTests : TestBase
	{
		[TestMethod]
		public async Task GetUserById()
		{
			var usersService = new UsersService(BaseUri, HttpClient);
			var user = await usersService.GetUserAsync(1);
			Assert.IsNotNull(user);
		}

		[TestMethod]
		public async Task GetUserByUsername()
		{
			var usersService = new UsersService(BaseUri, HttpClient);
			var user = await usersService.GetUserAsync("ben");
			Assert.IsNotNull(user);
		}

		[TestMethod, ExpectedException(typeof(ApiException))]
		public async Task GetAuthenticatedUser_WithInvalidApiKeyThrowsException()
		{
			var usersService = new UsersService(BaseUri, HttpClient);
			var user = await usersService.GetAuthenticatedUserAsync("NotARealApiKey");
		}
	}
}
