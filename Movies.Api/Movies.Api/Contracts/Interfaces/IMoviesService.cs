using System.Collections.Generic;
using System.Threading.Tasks;
using Movies.Api.Contracts.Requests;
using Movies.Api.Models;

namespace Movies.Api.Contracts.Interfaces
{
    public interface IMoviesService
    {
        public Task<IEnumerable<Movie>> GetAll();

        public Task<Movie> GetById(int id);

        public Task<Movie> Add(Movie movie);

        public Task<Movie> Update(int id, MovieRequest request);

        public Task<Movie> Delete(int id);
    }
}
