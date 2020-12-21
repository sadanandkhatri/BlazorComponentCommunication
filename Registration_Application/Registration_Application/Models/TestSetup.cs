using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Registration_Application.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration_Application.Models
{
    public class TestSetup : Startup
    {
      
        public TestSetup(IConfiguration configuration) : base(configuration)
        {

        }

        public void ConfigureTestServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            ///services.Replace<SignInManager<ApplicationUser>, MockSigninManager>(ServiceLifetime.Transient);
        }


    }
}
