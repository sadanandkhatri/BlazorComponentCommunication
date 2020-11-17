using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Registration_Application.Models
{
    public class ApplicationUser : IdentityUser
    {
        //[Column (TypeName = "Date")]
        public DateTime DOb { get; set; }
    }
}
