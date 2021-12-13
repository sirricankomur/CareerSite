using CareerSite.Entity.Concrete;
using System.Collections.Generic;

namespace CareerSite.MvcWebUI.Models
{
    public class CourseListViewModel
    {
        public PageInfo PageInfo { get; set; }
        public List<Course> Courses { get; set; }
    }
}
