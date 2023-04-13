using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularMovieAPI2.Environment;
using AngularMovieAPI2.Models.Show;
using AngularMovieAPI2.ModelsDto.ShowDto;
using AngularMovieAPI2.Services.ShowsService;

namespace AngularMovieAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private IShowService context { get; set; }
        public ShowController(IShowService _context)
        {
            context = _context;
        }


        [HttpGet]
        public async Task<IActionResult> GetShows()
        {
            try
            {
                var Shows = await context.GetShows();
                return Ok(Shows);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpGet("{ShowID}")]
        public async Task<IActionResult> GetShowByID(int ShowID)
        {
            try
            {
                var Show = await context.GetShowByID(ShowID);
                return Ok(Show);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }
        [HttpGet("Movie/{MovieID}")]
        public async Task<IActionResult> GetShowByMovieID(int MovieID)
        {
            try
            {
                var Show = await context.GetShowByMovieID(MovieID);
                return Ok(Show);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }


        [HttpPost("CreateShow")]
        public async Task<IActionResult> CreateShow(ShowDetailsDto Show)
        {
            try
            {
                var newShow = await context.CreateShow(Show);
                return Ok(newShow);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpPut("UpdateShow/{ShowID}")]
        public async Task<IActionResult> UpdateCinema([FromBody] ShowDetailsDto Show, int ShowID)
        {
            try
            {
                var updateShow = await context.UpdateShow(Show, ShowID);
                return Ok(updateShow);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }


        [HttpDelete("DeleteShow/{ShowID}")]
        public async Task<IActionResult> DeleteShow(int ShowID)
        {
            try
            {
                var deleteShow = await context.DeleteShow(ShowID);
                return Ok(deleteShow);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
