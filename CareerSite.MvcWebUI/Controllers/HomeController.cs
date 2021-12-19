using CareerSite.Business.Abstract;
using CareerSite.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Globalization;
using System.Threading;

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

        public IActionResult Index(string language)
        {
            var courseViewModel = new CourseListViewModel()
            {
                Courses = _courseService.GetHomePageCourses()
            };

            return View(courseViewModel);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View("MyView");
        }
    }

}
