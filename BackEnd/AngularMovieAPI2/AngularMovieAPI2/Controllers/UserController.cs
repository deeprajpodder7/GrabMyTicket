using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularMovieAPI2.Environment;
using AngularMovieAPI2.Models.User;
using AngularMovieAPI2.Helper;
using AngularMovieAPI2.Services.UserService;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AngularMovieAPI2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        public IUserService context { get; set; }
        public UserController(IUserService _context, IMapper mapper, IOptions<AppSettings> appSetings) // Depoedency Injection
        {
            context = _context;
            _mapper = mapper;
            _appSettings = appSetings.Value;
        }

        //AllowAnonymous lets users who have not been authenticated access the action or controller.In short, it knows based on the token it receives from the client.

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateModel model)
        //When passing any sensitive data (usernames, passwords, credit card information, etc.) via the request body, it is imperative to use [FromBody] in every case.
        {
            try
            {
                var user = await context.Authenticate(model.UserName, model.Password);

                if (user == null)
                {
                    return BadRequest(new { message = "Username or password is incorrect" });
                }
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.UserID.ToString())
                }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                // return basic user info and authentication token
                var userModel = _mapper.Map<UserModel>(user);
                userModel.Token = tokenString;
                userModel.DateCreated = DateTime.UtcNow;
                userModel.UserName.ToLower();
                return Ok(userModel);
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }


        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModelUser model)
        {
            var user = _mapper.Map<User>(model);
            try
            {
                // Create user
                await context.Create(user, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        //Http Get Request to Get All Users Frmo the Database.
        [HttpGet]
        [Authorize]

        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await context.GetAllUsers();
                var model = _mapper.Map<IList<UserModel>>(users);

                return Ok(model);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }

            //Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjYiLCJuYmYiOjE2MzE4MTQxNTEsImV4cCI6MTYzMjQxODk1MSwiaWF0IjoxNjMxODE0MTUxfQ.1LVukqBLZR2GiZI1P4_9ItrxuVALHXPDRR - VzkrBagM
        }


        [HttpGet("{id}")]
        [Authorize]

        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var user = await context.GetById(id);
                var model = _mapper.Map<UserModel>(user);
                return Ok(model);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });

            }

        }

        [HttpDelete("id")]
        [Authorize]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await context.delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });

            }

        }


        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateModel model)
        {
            // Map modelto entity and set id.
            var user = _mapper.Map<User>(model);
            user.UserID = id;

            try
            {
                // Update user
                await context.Update(user, model.Password);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(new { message = e.Message });
            }
        }

    }
}
