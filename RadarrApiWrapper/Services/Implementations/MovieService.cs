using Newtonsoft.Json;
using NJsonSchema.Infrastructure;
using NzbDrone.Core.MediaFiles.MediaInfo;
using NzbDrone.Core.Movies;
using RestSharp;

namespace RadarrApiWrapper.Services.Implementations
{
    public class MovieService : Interfaces.IMovieService
    {
        private readonly RestClient _restSharpClient;

        public MovieService(RestClient restSharpClient)
        {
            _restSharpClient = restSharpClient;
        }

        /// <summary>
        /// Get all movies.
        /// </summary>
        /// <returns>Returns all movies stored in the Radarr library</returns>
        public async Task<IList<Movie>?> GetMovies()
        {
            var request = new RestRequest("api/v3/movie");
            var response = await _restSharpClient.ExecuteGetAsync(request);

            #region JsonSerializerSettings
            // This is added because MediaInfoModel.RunTime was not being returned correctly from Radarr. So the property will just be ignored in this instance

            var jsonResolver = new PropertyRenameAndIgnoreSerializerContractResolver();
            jsonResolver.IgnoreProperty(typeof(MediaInfoModel), "RunTime");

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = jsonResolver
            };
            #endregion

            return JsonConvert.DeserializeObject<IList<Movie>>(response.Content, jsonSerializerSettings);
        }

        /// <summary>
        /// Get a movie by id.
        /// </summary>
        /// <param name="id">Database Id of movie to return</param>
        /// <returns>Returns a single movie</returns>
        public async Task<Movie?> GetMovie(int id)
        {
            var request = new RestRequest($"api/v3/movie/{id}");
            var response = await _restSharpClient.ExecuteGetAsync(request);
            return JsonConvert.DeserializeObject<Movie>(response.Content);
        }
    }
}
