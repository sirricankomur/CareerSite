using CareerSite.Entities.Concrete;

namespace CareerSite.MvcWebUI.Models
{
    public class CourseViewModel
    {
        public PageInfo PageInfo { get; set; }
        public List<Course> Courses { get; set; }

    }
}
