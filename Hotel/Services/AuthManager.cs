using Hotel.Data;
using Hotel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly IConfiguration _configuration;
        private ApiUser _user;

        public AuthManager(UserManager<ApiUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration; 
        }

        public async Task<string> CreateToken()
        {
            var signinCredentials = GetSigninCredentials();
            var claims =await GetClaims();
            var tokenOptions = GenerateTokenOptions(signinCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
         }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signinCredentials, List<Claim> claims)
        {
            var jwtSetting = _configuration.GetSection("Jwt");
            var expires = DateTime.Now.AddMinutes(Convert.ToDouble(jwtSetting.GetSection("lifetime").Value));

            var token = new JwtSecurityToken(
               issuer: jwtSetting.GetSection("validIssuer").Value,
               claims: claims,
               expires: expires,
               signingCredentials: signinCredentials
               );


            return token;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(_user);

            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

 


        private SigningCredentials GetSigninCredentials()
        {
            var key = Environment.GetEnvironmentVariable("KEY");
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }


        public async Task<bool> ValidateUser(LoginDTO userDTO)
        {
            _user = await _userManager.FindByNameAsync(userDTO.Email);
            var isPasswordCorrect = await _userManager.CheckPasswordAsync(_user, userDTO.Password);

            return (_user != null && isPasswordCorrect);
        }
    }
}
