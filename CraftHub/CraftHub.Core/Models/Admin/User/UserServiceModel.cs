using System.ComponentModel.DataAnnotations;

namespace CraftHub.Core.Models.Admin.User
{
    public class UserServiceModel
    {
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Full Name")]
        public string? FullName { get; set; } 

        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        public bool IsCreator { get; set; }
    }
}
