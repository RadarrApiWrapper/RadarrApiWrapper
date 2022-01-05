using RadarrApiWrapper.Services.Implementations;
using RadarrApiWrapper.Services.Interfaces;
using RestSharp;

namespace RadarrApiWrapper
{
    public class RadarrClient : IRadarrClient
    {

        /// <summary>
        /// Movie service
        /// </summary>
        public IMovieService Movie { get; }

        public RadarrClient(IRestClient restSharpClient)
        {
            Movie = new MovieService(restSharpClient);
        }
    }
}
