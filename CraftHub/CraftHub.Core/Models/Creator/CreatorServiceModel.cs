using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CraftHub.Core.Models.Creator
{
    public class CreatorServiceModel
    {
        public string PhoneNumber { get; set; } = null!;

        public string FullName { get; set; } = string.Empty;

        public string BusinessName { get; set; } = string.Empty;

        public string Email { get; set; } = null!;

        public string Website { get; set; } = string.Empty;

    }
}
