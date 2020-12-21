using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Registration_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration_Application.Mock
{
    public class MockSigninManager : SignInManager<ApplicationUser>
    {
        public MockSigninManager(
        UserManager<ApplicationUser> userManager,
        IHttpContextAccessor contextAccessor,
        IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory,
        IOptions<IdentityOptions> optionsAccessor,
        ILogger<SignInManager<ApplicationUser>> logger,
        IAuthenticationSchemeProvider authProvider, IUserConfirmation<ApplicationUser> userConformation)
        : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, authProvider, userConformation)
        {
        }

        public override Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            if (userName == "valid" && password == "valid@123")
            {
                return Task.FromResult(SignInResult.Success);
            }

            return Task.FromResult(SignInResult.Failed);
        }
    }
}
