using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CareerSite.MvcWebUI.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "{0} is required!")]
        [DisplayName("FirstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [DisplayName("LastName")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [DisplayName("UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [DisplayName("RePassword")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }


        [Required(ErrorMessage = "{0} is required!")]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
