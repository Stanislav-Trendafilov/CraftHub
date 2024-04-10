using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static CraftHub.Core.Constants.MessageConstants;
using static CraftHub.Infrastructure.DataConstants;


namespace CraftHub.Core.Models.Creator
{
    public class BecomeCreatorFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(CreatorPhoneNumberMaxLength, MinimumLength = CreatorPhoneNumberMinLength, ErrorMessage = LengthMessage)]
        [Display(Name = "Phone number")]
        [Phone]
        public string PhoneNumber { get; set; } = null!;
    }
}
