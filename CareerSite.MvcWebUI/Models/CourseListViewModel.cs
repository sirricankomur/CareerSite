using CareerSite.Entities.Concrete;
using System.Collections.Generic;

namespace CareerSite.MvcWebUI.Models
{
    public class CourseListViewModel
    {
        public List<Course> Courses { get; set; }
        public int PageCount { get; internal set; }
        public int PageSize { get; internal set; }
        public int CurrentCategory { get; internal set; }
        public int CurrentPage { get; internal set; }
    }
}
