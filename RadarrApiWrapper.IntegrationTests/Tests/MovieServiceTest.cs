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
        private readonly ITestOutputHelper _outputHelper;

        public MovieServiceTest(ITestOutputHelper outputHelper, CommonHelper commonHelper)
        {
            _commonHelper = commonHelper;
            _outputHelper = commonHelper.OutputHelper = outputHelper;
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
            Assert.NotNull(movies);
            Assert.True(movies.Count > 1, "Expected movies count to be greater than 0.");

            foreach (var movie in movies)
            {
                _outputHelper.WriteLine(movie.Title);
            }
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
            Assert.NotNull(movie);
            Assert.Equal(64686, movie.TmdbId);

            _outputHelper.WriteLine(movie.Title);
        }
    }
}
