using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? ApplicationUserGuid { get; set; } // Connection to AspNetUsers Id
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        // Admin or User
        public string Role { get; set; } = string.Empty;


        // Navigation property
        public int? TeamId { get; set; }
        public Team? Team { get; set; }
        

    }
}
