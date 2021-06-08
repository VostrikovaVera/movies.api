using System.Collections.Generic;
using System.Threading.Tasks;
using Movies.Api.Models;

namespace Movies.Api.Contracts.Interfaces
{
    public interface IMoviesService
    {
        public Task<IEnumerable<Movie>> GetAllMovies();

        public Task<Movie> AddMovie(Movie movie);
    }
}
