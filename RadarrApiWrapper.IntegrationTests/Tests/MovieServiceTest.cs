using RadarrApiWrapper.IntegrationTests.Common.Helpers;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RadarrApiWrapper.IntegrationTests.Tests
{
    [Collection(nameof(CommonHelper))]
    public class MovieServiceTest
    {
        private readonly CommonHelper _commonHelper;

        public MovieServiceTest(ITestOutputHelper outputHelper, CommonHelper commonHelper)
        {
            commonHelper.OutputHelper = outputHelper;
            _commonHelper = commonHelper;
        }

        [Fact]
        public async Task GetMovies()
        {
            var radarrClient = new RadarrClient(_commonHelper.RestClient);

            var movies = await  radarrClient.Movie.GetMovies();
            
            Assert.True(movies.Count > 1, "Expected movies count to be greater than 0.");
        }

        [Fact]
        public async Task GetMovie()
        {
            var radarrClient = new RadarrClient(_commonHelper.RestClient);

            var movie = await radarrClient.Movie.GetMovie(1);

            Assert.Equal(64686, movie.TmdbId);
        }
    }
}
