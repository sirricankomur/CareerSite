using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Entity.Concrete
{
    public class Course
    {
        public int CourseId { get; set; }
        public string NameTr { get; set; }
        public string NameEn { get; set; }
        public string Url { get; set; }
        public double? Price { get; set; }
        public string DescriptionTr { get; set; }
        public string DescriptionEn { get; set; }
        public string ImageUrl { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }

        public DateTime DateAdded { get; set; }

        public List<CourseCategory> CourseCategories { get; set; }
    }
}
