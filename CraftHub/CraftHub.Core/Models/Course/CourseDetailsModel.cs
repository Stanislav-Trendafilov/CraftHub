using CraftHub.Core.Models.Creator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftHub.Core.Models.Course
{
    public class CourseDetailsModel  :CourseServiceModel
    {
        public string Category { get; set; } = string.Empty;
        public CreatorServiceModel Creator { get; set; } = null!;
    }
}
