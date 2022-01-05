using RadarrApiWrapper.Services.Interfaces;

namespace RadarrApiWrapper;

public interface IRadarrClient
{
    /// <summary>
    /// Movie service
    /// </summary>
    IMovieService Movie { get; }
}