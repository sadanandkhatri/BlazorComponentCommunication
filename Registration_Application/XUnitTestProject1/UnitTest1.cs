using Registration_Application.Controllers;
using System;
using Xunit;
using Moq;
using Registration_Application.Models;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

using Registration_Application.Models;

namespace XUnitTestProject1
{
    public class UnitTest1
    {

         
       // _user.Setup(usermanager => usermanager);
        //private static 
        
        


        [Fact]
        public void  Test1Async()
        {
            //    Mock<UserManager<ApplicationUser>> _user = new Mock<UserManager<ApplicationUser>>();
            //    _user.Setup(usermanager => usermanager.IsInRoleAsync(It.IsAny<ApplicationUser>(), "Ramya")).ReturnsAsync(true);
            //    Mock<IOptions<ApplicationSettings>> mockappsettings = new Mock<IOptions<ApplicationSettings>>();
            //    ApplicationController _controller = new ApplicationController(_user.Object, mockappsettings.Object);
            //var result = await _controller.PostUser(new UserDetails() { UserName = "123", Password = "123@Ab", Dob = DateTime.Now, Email="123@gmail.com" });
            //    await Assert.IsType<Task<Object>>(result);

            var model = new LoginViewModel
            {
                Username = "valid@valid.com",
                password = "valid"
            };

            var redirectUrl = "api/Application/Login";

            ApplicationController controller = new ApplicationController();

            MyController<ApplicationController>
                .Instance()
                .Calling(c => c.Login(model, redirectUrl))
                .ShouldHave()
                .ValidModelState()
                .AndAlso()
                .ShouldReturn()
                .Redirect(result => result
                    .ToUrl(redirectUrl));
        }
    }
}
