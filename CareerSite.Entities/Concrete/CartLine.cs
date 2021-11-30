using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Entities.Concrete
{
    public class CartLine
    {
        public Course Course { get; set; }
        public int Quantity { get; set; }
    }
}
