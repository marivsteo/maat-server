using Maat.API.Helpers;
using Maat.Domain.DTO;
using Maat.Domain.Enums;
using Maat.Domain.Models;
using Maat.Services.Abstractions;
using Maat.Services.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maat.API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtService _jwtService;

        public AuthController(IUserService userService, JwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                Password =BCrypt.Net.BCrypt.HashPassword(dto.Password),
                DateOfBirth = dto.DateOfBirth,
                Gender = (GenderEnum)dto.Gender
            };
            try
            {
                return Created("user created", _userService.CreateUser(user));
            }
            catch (EmailAlreadyExistsException e)
            {
                return StatusCode(409);
            }
            
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        { 
            try
            {
                var user = _userService.AttemptLogin(dto.Email, dto.Password);

                var jwt = _jwtService.Generate(user.Id);

                Response.Cookies.Append("jwt", jwt, new CookieOptions 
                { 
                    HttpOnly = true
                });

                return Ok(new {
                    message = "success"
                });
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (InvalidCredentialsException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("user")]
        public IActionResult GetUser()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var user = _userService.GetUserById(userId);

                return Ok(user);
            }
            catch(Exception e)
            {
                return Unauthorized();
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");

            return Ok(new { message = "logout successful!" });
        }
    }
}
