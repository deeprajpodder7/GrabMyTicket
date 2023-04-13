using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularMovieAPI2.Models.Cinema;
using AngularMovieAPI2.ModelsDto.CinemaDto;
using AngularMovieAPI2.Services.CinemaAddressService;

namespace AngularMovieAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaAddressController : ControllerBase
    {
        public ICinemaAddressService context { get; set; }

        public CinemaAddressController(ICinemaAddressService _context)
        {
            context = _context;
        }


        [HttpGet]
        public async Task<IActionResult> GetCinemaAddresses()
        {
            try
            {
                var Addresses = await context.GetCinemaAddresses();
                return Ok(Addresses);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpGet("{AddressID}")]
        public async Task<IActionResult> GetCinemaAddressByID(int AddressID)
        {
            try
            {
                var cinemaAddress = await context.GetCinemaAddressByID(AddressID);
                return Ok(cinemaAddress);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpPost("CreateCinemaAddress")]
        public async Task<IActionResult> CreateAddress([FromBody] AddressDto cinemaAddress)
        {
            try
            {
                var newAddress = await context.CreateCinemaAddress(cinemaAddress);
                return Ok(newAddress);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }


        [HttpPut("UpdateCinemaAddress/{AddressID}")]
        public async Task<IActionResult> UpdateGenre([FromBody] AddressDto cinemaAddress, int AddressID)
        {
            try
            {
                var updateAddress = await context.UpdateCinemaAddress(cinemaAddress, AddressID);
                return Ok(updateAddress);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpDelete("DeleteGenre/{AddressID}")]
        public async Task<IActionResult> DeleteGenre(int AddressID)
        {
            try
            {
                var deleteAddress = await context.DeleteCinemaAddress(AddressID);
                return Ok(deleteAddress);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
