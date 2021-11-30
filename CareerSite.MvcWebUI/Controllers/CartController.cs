using CareerSite.Business.Abstract;
using CareerSite.MvcWebUI.Models;
using CareerSite.MvcWebUI.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CareerSite.MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private ICartSessionService _cartSessionService;
        private ICartService _cartService;
        private ICourseService _courseService;

        public CartController(
            ICartSessionService cartSessionService,
            ICartService cartService,
            ICourseService courseService)
        {
            _cartSessionService = cartSessionService;
            _cartService = cartService;
            _courseService = courseService;
        }

        public ActionResult AddToCart(int courseId)
        {
            var courseToBeAdded = _courseService.GetById(courseId);

            var cart = _cartSessionService.GetCart();

            _cartService.AddToCart(cart, courseToBeAdded);

            _cartSessionService.SetCart(cart);

            TempData.Add("message", String.Format("Your course, {0}, was successfully added to the cart!", courseToBeAdded.Name));

            return RedirectToAction("Index", "Course");
        }

        public ActionResult List()
        {
            var cart = _cartSessionService.GetCart();
            CartListViewModel cartListViewModel = new CartListViewModel
            {
                Cart = cart
            };
            return View(cartListViewModel);
        }

        public ActionResult Remove(int courseId)
        {
            var cart = _cartSessionService.GetCart();
            _cartService.RemoveFromCart(cart, courseId);
            _cartSessionService.SetCart(cart);
            TempData.Add("message", String.Format("Your course was successfully removed from the cart!"));
            return RedirectToAction("List");
        }

        /*
        public ActionResult Complete()
        {
            var shippingDetailsViewModel = new ShippingDetailsViewModel
            {
                ShippingDetails = new ShippingDetails()
            };
            return View(shippingDetailsViewModel);
        }

        [HttpPost]
        public ActionResult Complete(ShippingDetails shippingDetails)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            TempData.Add("message", String.Format("Thank you {0}, you order is in process", shippingDetails.FirstName));
            return View();
        }*/
    }
}
