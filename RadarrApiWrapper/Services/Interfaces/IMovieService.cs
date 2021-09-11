using NzbDrone.Core.Movies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RadarrApiWrapper.Services.Interfaces
{
    public interface IMovieService
    {
        /// <summary>
        /// Get All Movies
        /// </summary>
        /// <returns>Returns all movies stored in the database</returns>
        Task<IList<Movie>> GetMovies();

        /// <summary>
        /// Get a Movie
        /// </summary>
        /// <param name="id">Database Id of movie to return</param>
        /// <returns>Returns a single movie</returns>
        Task<Movie> GetMovie(int id);
    }
}