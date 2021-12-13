using CareerSite.Entity.Concrete;
using System.Collections.Generic;

namespace CareerSite.MvcWebUI.Models
{
    public class CourseDetailModel
    {
        public Course Course { get; set; }
        public List<Category> Categories { get; set; }
    }
}
