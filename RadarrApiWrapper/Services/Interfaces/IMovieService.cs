using NzbDrone.Core.Movies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RadarrApiWrapper.Services.Interfaces
{
    public interface IMovieService
    {
        /// <summary>
        /// Get all movies.
        /// </summary>
        /// <returns>Returns all movies stored in the Radarr library</returns>
        Task<IList<Movie>> GetMovies();
        
        /// <summary>
        /// Get a movie by id.
        /// </summary>
        /// <param name="id">Database Id of movie to return</param>
        /// <returns>Returns a single movie</returns>
        Task<Movie> GetMovie(int id);
    }
}