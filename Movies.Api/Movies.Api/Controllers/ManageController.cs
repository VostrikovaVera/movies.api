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
            var movies = await _moviesService.GetAllMovies();
            return movies is null ? NotFound("There are no movies yet") : Ok(movies.ToArray());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MovieRequest request)
        {
            await _moviesService.AddMovie(new Movie { Id = _random.Next(), Name = request.Name, DirectorName = request.DirectorName });
            return Ok();
        }

        // [HttpPut]

        // [HttpDelete]
    }
}
