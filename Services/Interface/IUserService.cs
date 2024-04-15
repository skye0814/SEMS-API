using Core.Entities;
using Core.WebModel.Request;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IUserService
    {
        Task<IdentityResult> AssignRole(string userId, string roleName);
        Task<ApplicationUser> GetUserFromToken(string token);
        Task<string> InsertApplicationUser(RegisterRequest request);
    }
}
