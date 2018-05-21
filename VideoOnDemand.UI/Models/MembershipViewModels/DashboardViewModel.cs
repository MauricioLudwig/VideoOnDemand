using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoOnDemand.UI.Models.DTOModels;

namespace VideoOnDemand.UI.Models.MembershipViewModels
{
    public class DashboardViewModel
    {
        public List<List<CourseDTO>> Courses { get; set; }
    }
}
