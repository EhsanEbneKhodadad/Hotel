using AutoMapper;
using Hotel.Data;
using Hotel.Models;
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
        // private readonly SignInManager<ApiUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;



        public AccountController(UserManager<ApiUser> userManagerm, ILogger<AccountController> logger, IMapper mapper)
        {
            _userManager = userManagerm;
            // _signInManager= signInManager;
            _logger= logger;
            _mapper=mapper;
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

                _userManager.AddToRolesAsync(user, userDTO.Roles);

                return Ok("Registed Successfully");
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }

        //[HttpPost]
        //[Route("login")]
        //public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return StatusCode(400, "Invalid Data");
        //    }

        //    try
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, false, false);

        //        if (!result.Succeeded)
        //        {
        //            return Unauthorized(loginDTO);
        //        }

        //        return Ok("Login Successfully");
        //    }
        //    catch (System.Exception)
        //    {

        //        return StatusCode(500, "Internal server error");
        //    }
        //}
    }
}
