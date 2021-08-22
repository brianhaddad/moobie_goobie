using System.Collections.Generic;
using ExternalMovieData.DTOs;

namespace ExternalMovieData
{
    public interface IExternalMovieData
    {
        public IEnumerable<MovieData> SearchByTitle(string movieTitle);
        public MovieData GetMovieData(string movieId);
    }
}
