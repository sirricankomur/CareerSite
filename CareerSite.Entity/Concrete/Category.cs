using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Entity.Concrete
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string NameTr { get; set; }
        public string NameEn { get; set; }
        public string UrlTr { get; set; }
        public string UrlEn { get; set; }
        public List<CourseCategory> CourseCategories { get; set; }
    }
}
