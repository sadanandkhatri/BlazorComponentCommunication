using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Registration_Application.Models;

namespace Registration_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private UserManager<ApplicationUser> _usermanager;
        private readonly ApplicationSettings _appsettings;

        //public ApplicationController() { }
        //private SignInManager<ApplicationUser> _signinmanager;

        public ApplicationController(UserManager<ApplicationUser> userManager,IOptions<ApplicationSettings> appSettings)
        {
            _usermanager = userManager;
            _appsettings = appSettings.Value;
            //_signinmanager = signInManager;
        }

        [HttpPost]
        [Route("Register")]  // api/Application/Register
        public async Task<Object> PostUser(UserDetails user)
        {
            Console.WriteLine(user.Dob);

            var applicationUser = new ApplicationUser()
            {
                UserName = user.UserName,
                DOb =   user.Dob,
                Email = user.Email
            };
            try
            {
                var result = await _usermanager.CreateAsync(applicationUser, user.Password);
                return Ok(result);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        [Route("Login")]// api/Application/Login

        public async Task<IActionResult> Login(LoginModel login)
        {
            var user = await _usermanager.FindByNameAsync(login.Username);
            if (user != null && await _usermanager.CheckPasswordAsync(user,login.Password))
            {
                var TockenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID", user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appsettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var TokenHandler = new JwtSecurityTokenHandler();
                var securitytoken = TokenHandler.CreateToken(TockenDescriptor);
                var token = TokenHandler.WriteToken(securitytoken);
                return Ok(new { token });
            }
            else
            {
                return BadRequest(new { message = "UserName or Password incorrect" });
            }
        }

    }
}
