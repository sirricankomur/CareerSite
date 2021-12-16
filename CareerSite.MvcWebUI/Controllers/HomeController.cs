using CareerSite.Business.Abstract;
using CareerSite.MvcWebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using System;

namespace CareerSite.MvcWebUI.Controllers
{
    public class HomeController : Controller
    {
        private IStringLocalizer<HomeController> _localizer;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;
        private ICourseService _courseService;
        public HomeController(ICourseService courseService, IStringLocalizer<HomeController> localizer, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _courseService = courseService;
            _localizer = localizer;
            _sharedLocalizer = sharedLocalizer;
        }

        public IActionResult Index()
        {
            var courseViewModel = new CourseListViewModel()
            {
                Courses = _courseService.GetHomePageCourses()
            };

            return View(courseViewModel);
        }
     

        //[HttpPost]
        //public IActionResult CultureManagement(string culture, string stringUrl)
        //{
        //    Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
        //        new CookieOptions { Expires =DateTimeOffset.Now.AddDays(30) }
        //        );

        //    return LocalRedirect(stringUrl);
        //}
   
    }

}
