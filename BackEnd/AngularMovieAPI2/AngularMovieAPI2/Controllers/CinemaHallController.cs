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
    public class CinemaHallController : ControllerBase
    {
        private ICinemaHallService context { get; set; }
        public CinemaHallController(ICinemaHallService _context)
        {
            context = _context;
        }


        [HttpGet]
        public async Task<IActionResult> GetCinemaHalls()
        {
            try
            {
                var CinemaHalls = await context.GetCinemaHalls();
                return Ok(CinemaHalls);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpGet("{CinemaHallID}")]
        public async Task<IActionResult> GetCinemaHallID(int CinemaHallID)
        {
            try
            {
                var CinemaHall = await context.GetCinemaHallByID(CinemaHallID);
                return Ok(CinemaHall);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpPost("CreateCinemaHall")]
        public async Task<IActionResult> CreateCinemaHall([FromBody] CinemaHallDto cinemaHall)
        {
            try
            {
                var newCinemaHall = await context.CreateCinemaHall(cinemaHall);
                return Ok(newCinemaHall);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }


        [HttpPut("UpdateCinemaHall/{CinemaHallID}")]
        public async Task<IActionResult> UpdateCinemaHall([FromBody] CinemaHallDto cinemaHall, int CinemaHallID)
        {
            try
            {
                var updateCinemaHall = await context.UpdateCinemaHall(cinemaHall, CinemaHallID);
                return Ok(updateCinemaHall);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpDelete("DeleteHallCinema/{CinemaHallID}")]
        public async Task<IActionResult> DeleteCinema(int CinemaHallID)
        {
            try
            {
                var deleteCinemaHall = await context.DeleteCinemaHall(CinemaHallID);
                return Ok(deleteCinemaHall);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
