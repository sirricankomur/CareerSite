using CareerSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Business.Abstract
{
    public interface ICartService
    {
        void AddToCart(Cart cart, Course course);
        void RemoveFromCart(Cart cart, int courseId);
        List<CartLine> List(Cart cart);
    }
}
