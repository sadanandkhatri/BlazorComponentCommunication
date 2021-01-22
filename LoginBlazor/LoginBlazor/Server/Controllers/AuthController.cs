using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginBlazor.Shared;

namespace LoginBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        static List<UserRegister> RegisterUser = new List<UserRegister>();
       [HttpPost("register")]
       public IActionResult Register(UserRegister request)
        {
            ServiceResponse<string> obj = new ServiceResponse<string>()
            {
                Data = "'Name':'admin'",
                Success = true,
                Message="Registration Successful"
            };
            RegisterUser.Add(request);
            return Ok(obj);
        }

        [HttpPost("login")]
        public IActionResult Login(UserLogin user)
        {
            UserRegister validuser = null;
            ServiceResponse<string> obj = new ServiceResponse<string>()
            {
                Data = "'Name':'Admin'"
                
            };
            if(RegisterUser.Count>0)
                 validuser = RegisterUser.Where(x => x.Email.Equals(user.Email) && x.Password.Equals(user.Password)).FirstOrDefault();
            //
            if (user.Email.Equals("admin@gmail.com") && user.Password.Equals("Admin@123"))
            {
                //return Object{Data };
                obj.Success = true;
                return Ok(obj);
            }
            obj.Success = false;
            obj.Message = "Invalid username or password";
            return BadRequest(obj);

        }
    }

   
}
