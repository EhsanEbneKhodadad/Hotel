using AutoMapper;
using Hotel.Data;
using Hotel.Models;
using Hotel.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;



        public AccountController(UserManager<ApiUser> userManagerm, IMapper mapper, IAuthManager authManager)
        {
            _userManager = userManagerm;
            _mapper=mapper;
            _authManager = authManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Invalid Data");
            }

            try
            {
                var user = _mapper.Map<ApiUser>(userDTO);
                user.UserName = userDTO.Email;
                var result = await _userManager.CreateAsync(user,userDTO.Password);

                if (!result.Succeeded)
                {
                    return StatusCode(500, result.Errors);
                }

                await _userManager.AddToRolesAsync(user, userDTO.Roles);

                return Ok("Registed Successfully");
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Invalid Data");
            }

            try
            {
                if(!await _authManager.ValidateUser(loginDTO)) { 
                    return Unauthorized();
                }

                return Ok(new {Token = _authManager.CreateToken()});
            }
            catch (System.Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }
    }
}
