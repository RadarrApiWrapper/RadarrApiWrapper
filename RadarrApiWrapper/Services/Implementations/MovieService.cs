using Newtonsoft.Json;
using NJsonSchema.Infrastructure;
using NzbDrone.Core.MediaFiles.MediaInfo;
using NzbDrone.Core.Movies;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RadarrApiWrapper.Services.Implementations
{
    public class MovieService : Interfaces.IMovieService
    {
        private readonly IRestClient _restSharpClient;

        public MovieService(IRestClient restSharpClient)
        {
            _restSharpClient = restSharpClient;
        }

        /// <summary>
        /// Get All Movies
        /// </summary>
        /// <returns>Returns all movies stored in the database</returns>
        public async Task<IList<Movie>> GetMovies()
        {
            var request = new RestRequest("api/v3/movie", Method.GET);
            var response = await _restSharpClient.ExecuteAsync(request);

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
        /// Get a Movie
        /// </summary>
        /// <param name="id">Database Id of movie to return</param>
        /// <returns>Returns a single movie</returns>
        public async Task<Movie> GetMovie(int id)
        {
            var request = new RestRequest($"api/v3/movie/{id}", Method.GET);
            var response = await _restSharpClient.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<Movie>(response.Content);
        }
    }
}
