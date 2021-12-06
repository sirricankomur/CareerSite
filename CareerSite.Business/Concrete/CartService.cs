using CareerSite.Business.Abstract;
using CareerSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Business.Concrete
{
    public class CartService : ICartService
    {
        public void AddToCart(Cart cart, Course course)
        {
            CartLine cartLine = cart.CartLines.FirstOrDefault(c => c.Course.CourseID == course.CourseID);
            if (cartLine != null)
            //if (cartLine.Quantity == 1)
            {
                cartLine.Quantity++;
                return;
            }
            cart.CartLines.Add(new CartLine { Course = course, Quantity = 1 });
        }

        public void RemoveFromCart(Cart cart, int courseId)
        {
            cart.CartLines.Remove(cart.CartLines.FirstOrDefault(c => c.Course.CourseID == courseId));
        }

        public List<CartLine> List(Cart cart)
        {
            return cart.CartLines;
        }
    }
}
