using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Registration_Application.Models;

namespace Registration_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<ApplicationUser> _usermanager;
        public UserProfileController(UserManager<ApplicationUser> userManager)
        {
            _usermanager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<Object> GetUserData()
        {
            string userid = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _usermanager.FindByIdAsync(userid);
            return new { user.UserName,user.DOb.Date,user.Email};
        }
    }
}
