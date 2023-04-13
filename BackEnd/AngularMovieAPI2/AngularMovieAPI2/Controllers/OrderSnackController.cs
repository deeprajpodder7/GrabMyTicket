using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularMovieAPI2.Environment;
using AngularMovieAPI2.Models.Snacks;
using AngularMovieAPI2.ModelsDto.SnackDto;
using AngularMovieAPI2.Services.SnackService;

namespace AngularMovieAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderSnackController : ControllerBase
    {
        public IOrderSnackService context { get; set; }

        public OrderSnackController(IOrderSnackService _context)
        {
            context = _context;
        }


        [HttpGet]
        public async Task<IActionResult> GetOrderSnacks()
        {
            try
            {
                var OrderSnacks = await context.getOrderSnacks();
                return Ok(OrderSnacks);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }


        [HttpGet("{OrderSnackID}")]
        public async Task<IActionResult> GetOrderSnackID(int OrderSnackID)
        {
            try
            {
                var OrderSnack = await context.GetOrderSnackByID(OrderSnackID);
                return Ok(OrderSnack);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpPost("CreateOrderSnack")]
        public async Task<IActionResult> CreateOrderSnack([FromBody] OrderSnackDto OrderSnack)
        {
            try
            {
                var newOrderSnack = await context.CreateOrderSnack(OrderSnack);
                return Ok(newOrderSnack);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }


        [HttpPut("UpdateOrderSnack/{OrderSnackID}")]
        public async Task<IActionResult> UpdateOrderSnack([FromBody] OrderSnackDto OrderSnack, int OrderSnackID)
        {
            try
            {
                var updateOrderSnack = await context.UpdateOrderSnack(OrderSnack, OrderSnackID);
                return Ok(updateOrderSnack);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpDelete("DeleteOrderSnack/{OrderSnackID}")]
        public async Task<IActionResult> DeleteOrderSnack(int OrderSnackID)
        {
            try
            {
                var deleteOrderSnack = await context.DeleteOrderSnack(OrderSnackID);
                return Ok(deleteOrderSnack);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
