using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Entities.Concrete
{
    public class RecordItem
    {
        public int Id { get; set; }
        public int RecordId { get; set; }
        public Record Record { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public double Price { get; set; }
        public int Quantity { get; set; }

    }
}
