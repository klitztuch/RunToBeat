using System;
using System.Threading.Tasks;
using NUnit.Framework;
using RunToBeat.Api.Services;

namespace RunToBeat.Api.UnitTest.Services
{
    [TestFixture]
    public class SpotifyAuthenticationServiceTest
    {
        [SetUp]
        public void Setup()
        {
            _authenticationService = new SpotifyAuthenticationService("",
                "");
        }

        private ISpotifyAuthenticationService _authenticationService;

        [Test]
        public async Task GetRequestTokenTest()
        {
            var token = await _authenticationService.GetRequestToken();
            Assert.NotNull(token, "token != null");
            Assert.IsFalse(token.IsExpired, "token.IsExpired");
            Assert.IsTrue(token.CreatedAt < DateTime.Now, "token.CreatedAt < DateTime.Now");
        }
    }
}