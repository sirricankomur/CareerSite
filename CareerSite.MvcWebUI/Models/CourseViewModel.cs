using CareerSite.Entity.Concrete;
using System.Collections.Generic;

namespace CareerSite.MvcWebUI.Models
{
    public class CourseViewModel
    {
        public PageInfo PageInfo { get; set; }
        public List<Course> Courses { get; set; }
    }
}
