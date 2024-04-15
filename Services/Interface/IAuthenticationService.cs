using Core.WebModel.Response;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> CreateTokenAsync(IdentityUser user);
    }
}
