using Microsoft.AspNetCore.Identity;

namespace CareerSite.MvcWebUI.Identity
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
