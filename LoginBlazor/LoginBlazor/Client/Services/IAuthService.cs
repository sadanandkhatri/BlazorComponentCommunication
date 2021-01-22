using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginBlazor.Shared;

namespace LoginBlazor.Client.Services
{
    public interface IAuthService
    {
        Task<ServiceResponse<string>> Register(UserRegister request);
        Task<ServiceResponse<string>> Login(UserLogin request);
    }
}
