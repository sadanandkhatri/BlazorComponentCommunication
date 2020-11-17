using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration_Application.Models
{
    public class UserDetails
    {
        public string UserName { get; set; }
        public DateTime Dob { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
