using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularMovieAPI2.Environment;
using AngularMovieAPI2.Models.Movie;
using AngularMovieAPI2.ModelsDto.GenreDto;
using AngularMovieAPI2.Services.GenreService;

namespace AngularMovieAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        public IGenreService context { get; set; }

        public GenreController(IGenreService _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> GetGenres()
        {
            try
            {
                var genres = await context.GetGenres();
                return Ok(genres);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpGet("{GenreID}")]
        public async Task<IActionResult> GetGenreByID(int GenreID)
        {
            try
            {
                var genres = await context.GetGenreByID(GenreID);
                return Ok(genres);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpPost("CreateGenre")]
        public async Task<IActionResult> CreateGenre([FromBody] CreateGenre createGenre)
        {
            try
            {
                var newGenre = await context.CreateGenre(createGenre);
                return Ok(newGenre);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpPut("UpdateGenre/{GenreID}")]
        public async Task<IActionResult> UpdateGenre([FromBody] GenreDto updateGenre, int GenreID)
        {
            try
            {
                var newGenre = await context.UpdateGenre(updateGenre, GenreID);
                return Ok(newGenre);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpDelete("DeleteGenre/{GenreID}")]
        public async Task<IActionResult> DeleteGenre(int GenreID)
        {
            try
            {
                var deletGenre = await context.DeleteGenre(GenreID);
                return Ok(deletGenre);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}

