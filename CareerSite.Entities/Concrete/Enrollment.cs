using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Entities.Concrete
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CategoryID { get; set; }
        public int CourseID { get; set; }
        public int MemberID { get; set; }

        public Category Category { get; set; }
        public Course Course { get; set; }
        public Member Member { get; set; }

    }
}
