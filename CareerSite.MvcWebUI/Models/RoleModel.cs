using CareerSite.MvcWebUI.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CareerSite.MvcWebUI.Models
{
    public class RoleModel
    {
        [Required]
        public string Name { get; set; }
    }


}
