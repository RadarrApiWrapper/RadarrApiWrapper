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

        /// <summary>
        /// Get all the movies and make sure that there are more than 1 movie in the Radarr library. 
        /// </summary>
        [Fact]
        public async Task GetMovies()
        {
            // Arrange
            var radarrClient = new RadarrClient(_commonHelper.RestClient);

            // Act
            var movies = await radarrClient.Movie.GetMovies();

            // Assert
            Assert.True(movies.Count > 1, "Expected movies count to be greater than 0.");
        }

        /// <summary>
        /// Get a movie by id and make sure that the movie is 47 Ronin (TmdbId: 64686). 
        /// </summary>
        [Fact]
        public async Task GetMovie()
        {
            // Arrange
            var radarrClient = new RadarrClient(_commonHelper.RestClient);

            // Act
            var movie = await radarrClient.Movie.GetMovie(1);

            // Assert
            Assert.Equal(64686, movie.TmdbId);
        }
    }
}
