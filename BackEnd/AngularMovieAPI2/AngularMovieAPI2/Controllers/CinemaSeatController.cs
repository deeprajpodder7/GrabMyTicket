using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularMovieAPI2.Environment;
using AngularMovieAPI2.Models.Cinema;
using AngularMovieAPI2.ModelsDto.CinemaDto;
using AngularMovieAPI2.Services.CinemaServices;

namespace AngularMovieAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaSeatController : ControllerBase
    {
        private ICinemaSeatService context { get; set; }
        public CinemaSeatController(ICinemaSeatService _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCinemaSeats()
        {
            try
            {
                var CinemaSeats = await context.GetCinemaSeats();
                return Ok(CinemaSeats);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpGet("{CinemaSeatID}")]
        public async Task<IActionResult> GetCinemaSeatID(int CinemaSeatID)
        {
            try
            {
                var CinemaSeat = await context.GetCinemaSeatByID(CinemaSeatID);
                return Ok(CinemaSeat);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpPost("CreateCinemaSeat")]
        public async Task<IActionResult> CreateCinemaSeat([FromBody] CinemaSeatModelDto CinemaSeat)
        {
            try
            {
                var newCinemaSeat = await context.CreateCinemaSeat(CinemaSeat);
                return Ok(newCinemaSeat);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }


        [HttpPut("UpdateCinemaSeat/{CinemaSeatID}")]
        public async Task<IActionResult> UpdateCinemaSeat([FromBody] CinemaSeatModelDto CinemaSeat, int CinemaSeatID)
        {
            try
            {
                var updateCinemaSeat = await context.UpdateCinemaSeat(CinemaSeat, CinemaSeatID);
                return Ok(updateCinemaSeat);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpDelete("DeleteCinemaSeat/{CinemaSeatID}")]
        public async Task<IActionResult> DeleteCinemaSeat(int CinemaSeatID)
        {
            try
            {
                var deleteCinemaSeat = await context.DeleteCinemaSeat(CinemaSeatID);
                return Ok(deleteCinemaSeat);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
