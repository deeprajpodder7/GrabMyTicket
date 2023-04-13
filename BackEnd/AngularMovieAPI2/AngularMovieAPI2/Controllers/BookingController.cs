using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularMovieAPI2.Models.Bookings;
using AngularMovieAPI2.ModelsDto.BookingDto;
using AngularMovieAPI2.Services.BookingsService;

namespace AngularMovieAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        public IBookingService context { get; set; }

        public BookingController(IBookingService _context)
        {
            context = _context;
        }


        [HttpGet]
        public async Task<IActionResult> GetBookings()
        {
            try
            {
                var bookings = await context.getBookings();
                return Ok(bookings);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }


        [HttpGet("{BookingID}")]
        public async Task<IActionResult> GetBookingID(int BookingID)
        {
            try
            {
                var Booking = await context.GetBookingByID(BookingID);
                return Ok(Booking);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpGet("User/{UserID}")]
        public async Task<IActionResult> GetBookingByUserID(int UserID)
        {
            try
            {
                var Booking = await context.GetBookingByuserID(UserID);
                return Ok(Booking);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }


        [HttpPost("CreateBooking")]
        public async Task<IActionResult> CreateBooking([FromBody] BookingDto Booking)
        {
            try
            {
                var newBooking = await context.CreateBooking(Booking);
                return Ok(newBooking);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }
        [HttpPost("CreateBookingWithData")]
        public async Task<IActionResult> CreateBookingWithData([FromBody] Booking Booking)
        {
            try
            {
                var newBooking = await context.CreateBookingWithData(Booking);
                return Ok(newBooking);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpPut("UpdateBooking/{BookingID}")]
        public async Task<IActionResult> UpdateBooking([FromBody] BookingDto Booking, int BookingID)
        {
            try
            {
                var updateBooking = await context.UpdateBooking(Booking, BookingID);
                return Ok(updateBooking);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpDelete("DeleteBooking/{BookingID}")]
        public async Task<IActionResult> DeleteBooking(int BookingID)
        {
            try
            {
                var deleteBooking = await context.DeleteBooking(BookingID);
                return Ok(deleteBooking);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
