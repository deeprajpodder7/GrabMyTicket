using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularMovieAPI2.Environment;
using AngularMovieAPI2.Models.Movie;
using AngularMovieAPI2.Helper;
using AngularMovieAPI2.ModelsDto.MovieDto;
using AngularMovieAPI2.Services.MovieService;

namespace AngularMovieAPI2.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        public IMovieService context { get; set; }

        public MovieController(IMovieService _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            try
            {
                var movies = await context.GetMovies();

                // var MovieWithGenre = mapper.Map<ICollection<MovieWithGenreName>>(movies);
                if (movies == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, movies);
                }
                else if (movies.Count() == 0) { return NoContent(); }
                return Ok(movies);
            }
            catch (AppException ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }


        [HttpGet("{MovieID}")]
        public async Task<IActionResult> GetMovieByID(int MovieID)
        {
            try
            {
                var MovieByID = await context.GetMoviesByID(MovieID).ConfigureAwait(false);

                if (MovieByID == null)
                {
                    return NotFound();
                }

                return Ok(MovieByID);
            }
            catch (AppException ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpGet("GenreMovie/{GenreID}")]
        public async Task<IActionResult> GetGenresMovie(int GenreID)
        {
            try
            {
                var GenresMovie = await context.GetGenresMovie(GenreID);
                return Ok(GenresMovie);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("CreateMovie")]
        public async Task<IActionResult> CreateMovie([FromBody] CreateMovieModel Createmodel)
        {

            try
            {
                if (!ModelState.IsValid || Createmodel == null)
                {
                    return BadRequest(ModelState);
                }
                // Create user
                var movie = await context.CreateMovie(Createmodel);

                return Created("", movie);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("UpdateMovie")]
        public async Task<IActionResult> UpdateMovie([FromBody] UpdateMovieModel UpdateModel)
        {
            try
            {
                var movie = await context.UpdateMovie(UpdateModel);
                return Ok(movie);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("DeleteMovie/{MovieID}")]
        public async Task<IActionResult> DeleteMovie(int MovieID)
        {
            try
            {
                var movieToDelete = await context.DeleteMovie(MovieID);
                if (movieToDelete == null)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {

                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
