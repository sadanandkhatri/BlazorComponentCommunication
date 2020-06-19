using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce1.Models
{
    public class UserRegistration
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string password { get; set; }

        public Boolean IsOwner { get; set; }

        public int getId()
        {
            return Id;
        }
    }
}