using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Entities.Concrete
{
    public class Cart
    {
        public List<CartLine> CartLines { get; set; }

        public decimal Total
        {
            get { return CartLines.Sum(c => c.Course.UnitPrice); }
        }

        public Cart()
        {
            CartLines = new List<CartLine>();
        }
    }
}
