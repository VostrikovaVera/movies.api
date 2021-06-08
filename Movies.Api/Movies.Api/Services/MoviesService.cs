using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movies.Api.Contracts.Interfaces;
using Movies.Api.Contracts.Requests;
using Movies.Api.Models;

namespace Movies.Api.Services
{
    public class MoviesService : IMoviesService
    {
        private static readonly List<Movie> _movies = new List<Movie>();

        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await Task.FromResult(_movies);
        }

        public async Task<Movie> GetById(int id)
        {
            return await Task.FromResult(_movies.Where(m => m.Id == id).FirstOrDefault());
        }

        public async Task<Movie> Add(Movie movie)
        {
            _movies.Add(movie);

            return await Task.FromResult(movie);
        }

        public async Task<Movie> Update(int id, MovieRequest request)
        {
            var movie = await GetById(id);

            if (movie != null)
            {
                movie.Name = request.Name;
                movie.DirectorName = request.DirectorName;
            }

            return await Task.FromResult(movie);
        }

        public async Task<Movie> Delete(int id)
        {
            var movie = await GetById(id);

            if (movie != null)
            {
                _movies.RemoveAll(m => m.Id == id);
            }

            return await Task.FromResult(movie);
        }
    }
}