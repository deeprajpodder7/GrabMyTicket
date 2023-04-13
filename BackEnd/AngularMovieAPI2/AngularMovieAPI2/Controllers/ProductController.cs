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
    public class ProductController : ControllerBase
    {
        public IProductService context { get; set; }

        public ProductController(IProductService _context)
        {
            context = _context;
        }


        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var Products = await context.getProducts();
                return Ok(Products);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }


        [HttpGet("{ProductID}")]
        public async Task<IActionResult> GetProductID(int ProductID)
        {
            try
            {
                var Product = await context.GetProductByID(ProductID);
                return Ok(Product);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto Product)
        {
            try
            {
                var newProduct = await context.CreateProduct(Product);
                return Ok(newProduct);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }


        [HttpPut("UpdateProduct/{ProductID}")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDto Product, int ProductID)
        {
            try
            {
                var updateProduct = await context.UpdateProduct(Product, ProductID);
                return Ok(updateProduct);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }
        }

        [HttpDelete("DeleteProduct/{ProductID}")]
        public async Task<IActionResult> DeleteProduct(int ProductID)
        {
            try
            {
                var deleteProduct = await context.DeleteProduct(ProductID);
                return Ok(deleteProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
