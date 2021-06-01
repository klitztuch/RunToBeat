using System;
using System.Threading.Tasks;
using NUnit.Framework;
using RunToBeat.Api.Services;

namespace RunToBeat.Api.UnitTest.Services
{
    [TestFixture]
    public class HappiDevMusicServiceTest
    {
        [SetUp]
        public void Setup()
        {
            _happiDevMusicService = new HappiDevMusicService("api.happi.dev/v1",
                "");
        }

        private IHappiDevMusicService _happiDevMusicService;

        [Test]
        public async Task GetRequestTokenTest()
        {
            var tracks = await _happiDevMusicService.GetTracksByBpm("90-100");
            
        }
    }
}