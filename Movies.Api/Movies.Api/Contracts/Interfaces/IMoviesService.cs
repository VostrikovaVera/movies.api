using System.Collections.Generic;
using System.Threading.Tasks;
using Movies.Api.Contracts.Requests;
using Movies.Api.Models;

namespace Movies.Api.Contracts.Interfaces
{
    public interface IMoviesService
    {
        public IEnumerable<Movie> GetAll();

        public Movie GetById(int id);

        public Movie Add(Movie movie);

        public Movie Update(int id, MovieRequest request);

        public Movie Delete(int id);
    }
}
