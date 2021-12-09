using CareerSite.Entities.Concrete;
using System.Collections.Generic;

namespace CareerSite.MvcWebUI.Models
{
    public class CourseListViewModel
    {
        public List<Course> Courses { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentCategory { get; set; }
        public int CurrentPage { get; set; }
    }
}
