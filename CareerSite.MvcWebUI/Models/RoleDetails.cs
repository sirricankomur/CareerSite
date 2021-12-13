using CareerSite.MvcWebUI.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CareerSite.MvcWebUI.Models
{

    public class RoleDetails
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<User> Members { get; set; }
        public IEnumerable<User> NonMembers { get; set; }
    }
}
