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

        public IEnumerable<Movie> GetAll()
        {
            return _movies;
        }

        public Movie GetById(int id)
        {
            return _movies.Where(m => m.Id == id).FirstOrDefault();
        }

        public Movie Add(Movie movie)
        {
            _movies.Add(movie);

            return movie;
        }

        public Movie Update(int id, MovieRequest request)
        {
            var movie = GetById(id);

            if (movie != null)
            {
                movie.Name = request.Name;
                movie.DirectorName = request.DirectorName;
            }

            return movie;
        }

        public Movie Delete(int id)
        {
            var movie = GetById(id);

            if (movie != null)
            {
                _movies.RemoveAll(m => m.Id == id);
            }

            return movie;
        }
    }
}