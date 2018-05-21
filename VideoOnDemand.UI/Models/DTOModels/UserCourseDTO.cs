using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace VideoOnDemand.UI.Models.DTOModels
{
    public class UserCourseDTO
    {
        [DisplayName("User Id")]
        public string UserId { get; set; }
        [DisplayName("Course Id")]
        public int CourseId { get; set; }
        [DisplayName("Email")]
        public string UserEmail { get; set; }
        [DisplayName("Title")]
        public string CourseTitle { get; set; }
    }
}
