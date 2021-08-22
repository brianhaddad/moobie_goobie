using ExternalMovieData.DTOs;
using System;
using System.Collections.Generic;

//TODO: https://jnrmnt.github.io/JMovies.IMDb/html/index.html
namespace ExternalMovieData
{
    public class MovieDataRetriever : IExternalMovieData
    {
        public MovieData GetMovieData(string movieId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovieData> SearchByTitle(string movieTitle)
        {
            throw new NotImplementedException();
        }
    }
}
