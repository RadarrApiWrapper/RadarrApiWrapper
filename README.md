# RadarrApiWrapper
C# [Radarr](https://radarr.video/) API wrapper. It is still in an aplha phase so all methods are not implemented.

## Installation
Available as a [NuGet](https://www.nuget.org/packages/RadarrApiWrapper/) package:
```
PM> Install-Package RadarrApiWrapper
```

## Known Issues
- None ATM.

## Usage
These are some examples on how to use the API. All methods are async/awaitable. Most methods includes help text on what they do. If you need more information on how the various endpoints works, visit https://github.com/Radarr/Radarr/wiki/API.

Create the client:
```c#
var restClient = new RestClient("http://127.0.0.1:7878")
restClient.AddDefaultHeader("X-Api-Key", "apiKey");
```

Get all movies:
```c#
var movies = await radarrClient.Movie.GetMovies();
foreach (var item in movies)
{
    Console.WriteLine($"{item.Title}");
}
```

Get movie by Id:
```c#
var movie = await radarrClient.Movie.GetMovie(1);

// Get status of movie
Console.WriteLine($"{movie.Name}: {movie.State}");
```