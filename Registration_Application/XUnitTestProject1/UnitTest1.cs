using Registration_Application.Controllers;
using System;
using Xunit;
using Moq;
using Registration_Application.Models;

namespace XUnitTestProject1
{
    public class UnitTest1
    {

        Mock<Microsoft.AspNetCore.Identity.UserManager<ApplicationUser>> mockusermanager = new Mock<Microsoft.AspNetCore.Identity.UserManager<ApplicationUser>>();

       // ApplicationController _controller = new ApplicationController();

        [Fact]
        public void Test1()
        {

        }
    }
}
