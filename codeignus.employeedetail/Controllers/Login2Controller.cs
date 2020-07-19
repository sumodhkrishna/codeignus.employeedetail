using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using codeignus.employeedetails.core.Authorization;
using codeignus.employeedetails.core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace codeignus.employeedetail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Login2Controller : ControllerBase
    {
        public IConfiguration configuration;
        private List<UserInfoModel> appUsers = new List<UserInfoModel>
        {
            new UserInfoModel(){ UserName="sumodhkrishna", Password="password", UserRole = AuthorizationPolicies.ADMIN}
        };

        public Login2Controller(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(UserInfoModel userInfo)
        {
            var user = AuthenticateUser(userInfo);
            if (user != null)
            {
                return this.Ok(
                        new
                        {
                            token = GenerateJWTToken(user),
                            userDetails = user,
                        }
                    );
            }
            return this.Unauthorized();
        }


        [HttpGet]
        //[Authorize(Policy = AuthorizationPolicies.ADMIN)]
        [AllowAnonymous]
        public IActionResult LoggedInCheck()
        {
            return this.Ok("Working");
        }
        UserInfoModel AuthenticateUser(UserInfoModel loginCredentials)
        {
            var user = appUsers.SingleOrDefault(x => x.UserName == loginCredentials.UserName && x.Password == loginCredentials.Password);
            return user;
        }

        string GenerateJWTToken(UserInfoModel userInfo)
        {
            string s = this.configuration["Jwt:SecretKey"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(s));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                new Claim("username", userInfo.UserName.ToString()),
                new Claim("role",userInfo.UserRole),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            var token = new JwtSecurityToken(
            issuer: this.configuration["Jwt:Issuer"],
            audience: this.configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
