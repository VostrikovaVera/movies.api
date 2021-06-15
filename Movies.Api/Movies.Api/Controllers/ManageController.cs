using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movies.Api.Contracts.Interfaces;
using Movies.Api.Contracts.Requests;
using Movies.Api.Models;

namespace Movies.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManageController : ControllerBase
    {
        private readonly ILogger<ManageController> _logger;
        private readonly IMoviesService _moviesService;
        private readonly Random _random = new Random();

        public ManageController(ILogger<ManageController> logger, IMoviesService moviesService)
        {
            _logger = logger;
            _moviesService = moviesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var movies = await _moviesService.GetAll();

            return movies is null ? NotFound("Movies not found") : Ok(movies.ToArray());
        }

        [HttpGet]
        [Route("/[controller]/{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var movie = await _moviesService.GetById(id);

            return movie is null ? NotFound($"Movie with id {id} was not found") : Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MovieRequest request)
        {
            var response = await _moviesService.Add(new Movie { Id = _random.Next(), Name = request.Name, DirectorName = request.DirectorName });

            return Ok(response);
        }

        [HttpPut]
        [Route("/[controller]/{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] MovieRequest request)
        {
            var updatedMovie = await _moviesService.Update(id, request);

            return updatedMovie is null ? NotFound($"Movie with id {id} was not found") : Ok(updatedMovie);
        }

        [HttpDelete]
        [Route("/[controller]/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deletedMovie = await _moviesService.Delete(id);

            return deletedMovie is null ? NotFound($"Movie with id {id} was not found") : Ok();
        }
    }
}
