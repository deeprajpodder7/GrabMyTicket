using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularMovieAPI2.Models.Cinema;
using AngularMovieAPI2.ModelsDto.CinemaDto;
using AngularMovieAPI2.Services.CinemaServices;

namespace AngularMovieAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private ICinemaService context { get; set; }
        public CinemaController(ICinemaService _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCinemas()
        {
            try
            {
                var Cinemas = await context.GetCinemas();
                return Ok(Cinemas);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpGet("{CinemaID}")]
        public async Task<IActionResult> GetCinemaID(int CinemaID)
        {
            try
            {
                var Cinema = await context.GetCinemaByID(CinemaID);
                return Ok(Cinema);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpPost("CreateCinema")]
        public async Task<IActionResult> CreateCinema([FromBody] CinemaModelDto cinema)
        {
            try
            {
                var newCinema = await context.CreateCinema(cinema);
                return Ok(newCinema);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }


        [HttpPut("UpdateCinema/{CinemaID}")]
        public async Task<IActionResult> UpdateCinema([FromBody] CinemaModelDto cinema, int CinemaID)
        {
            try
            {
                var updateCinema = await context.UpdateCinema(cinema, CinemaID);
                return Ok(updateCinema);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpDelete("DeleteCinema/{CinemaID}")]
        public async Task<IActionResult> DeleteCinema(int CinemaID)
        {
            try
            {
                var deleteCinema = await context.DeleteCinema(CinemaID);
                return Ok(deleteCinema);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
