using CareerSite.Business.Abstract;
using CareerSite.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CareerSite.MvcWebUI.Controllers
{
    public class CourseController : Controller
    {
        private ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public IActionResult Index(int page = 1, int category = 0)
        {
            int pageSize = 10;
            var courses = _courseService.GetByCategory(category);

            CourseListViewModel model = new CourseListViewModel
            {
                Courses = courses.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                PageCount = (int)Math.Ceiling(courses.Count / (double)pageSize),
                PageSize = pageSize,
                CurrentCategory = category,
                CurrentPage = page
            };

            return View(model);
        }
    }
}
