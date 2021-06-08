using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movies.Api.Contracts.Interfaces;
using Movies.Api.Models;

namespace Movies.Api.Services
{
    public class MoviesService : IMoviesService
    {
        private static readonly List<Movie> _movies = new List<Movie>();

        // await Task.FromResult(true);

        /*public virtual async Task<TEntity> Create(TEntity entity)
        {
            if (!await CanModify(entity))
            {
                throw new PlkPermissionException(BuildAccessDeniedMessage(Operation.Create));
            }

            _dbContext.Set<TEntity>().Add(entity);

            return entity;
        }*/

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await Task.FromResult(_movies);
        }

        public async Task<Movie> AddMovie(Movie movie)
        {
            _movies.Add(movie);

            return await Task.FromResult(movie);
        }
    }
}