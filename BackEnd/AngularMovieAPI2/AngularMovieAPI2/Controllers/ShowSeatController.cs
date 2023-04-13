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
    public class ShowSeatController : ControllerBase
    {
        public IShowSeatService context { get; set; }

        public ShowSeatController(IShowSeatService _context)
        {
            context = _context;
        }


        [HttpGet]
        public async Task<IActionResult> GetShowSeats()
        {
            try
            {
                var ShowSeats = await context.getShowSeats();
                return Ok(ShowSeats);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }


        [HttpGet("{ShowSeatID}")]
        public async Task<IActionResult> GetShowSeatID(int ShowSeatID)
        {
            try
            {
                var ShowSeat = await context.GetShowSeatByID(ShowSeatID);
                return Ok(ShowSeat);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpGet("Show/{ShowID}")]
        public async Task<IActionResult> GetShowSeatsByShowID(int ShowID)
        {
            try
            {
                var ShowSeat = await context.getShowSeatsByShowID(ShowID);
                return Ok(ShowSeat);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }



        [HttpPost("CreateShowSeat")]
        public async Task<IActionResult> CreateShowSeat([FromBody] ShowSeatDto ShowSeat)
        {
            try
            {
                var newShowSeat = await context.CreateShowSeat(ShowSeat);
                return Ok(newShowSeat);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }


        [HttpPut("UpdateShowSeat/{ShowSeatID}")]
        public async Task<IActionResult> UpdateShowSeat([FromBody] ShowSeatDto ShowSeat, int ShowSeatID)
        {
            try
            {
                var updateShowSeat = await context.UpdateShowSeat(ShowSeat, ShowSeatID);
                return Ok(updateShowSeat);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpDelete("DeleteShowSeat/{ShowSeatID}")]
        public async Task<IActionResult> DeleteShowSeat(int ShowSeatID)
        {
            try
            {
                var deleteShowSeat = await context.DeleteShowSeat(ShowSeatID);
                return Ok(deleteShowSeat);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
