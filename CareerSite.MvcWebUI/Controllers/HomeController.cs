using CareerSite.Business.Abstract;
using CareerSite.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CareerSite.MvcWebUI.Controllers
{
    public class HomeController : Controller
    {

        private ICourseService _courseService;
        public HomeController(ICourseService courseService)
        {
            this._courseService = courseService;
        }

        public IActionResult Index()
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
