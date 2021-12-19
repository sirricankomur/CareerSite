using CareerSite.Business.Abstract;
using CareerSite.Entity.Concrete;
using CareerSite.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CareerSite.MvcWebUI.Controllers
{
    public class ShopController : Controller
    {
        private ICourseService _courseService;
        public ShopController(ICourseService courseService)
        {
            this._courseService = courseService;
        }

        public IActionResult List(string category, int page = 1)
        {
            const int pageSize = 6;
            var courseViewModel = new CourseListViewModel()
            {
                PageInfo = new PageInfo()
                {
                    TotalItems = _courseService.GetCountByCategory(category),
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    CurrentCategory = category
                },
                Courses = _courseService.GetCoursesByCategory(category, page, pageSize)
            };

            return View(courseViewModel);
        }

        public IActionResult Details(string url)
        {
            if (url == null)
            {
                return NotFound();
            }
            Course course = _courseService.GetCourseDetails(url);

            if (course == null)
            {
                return NotFound();
            }
            return View(new CourseDetailModel
            {
                Course = course,
                Categories = course.CourseCategories.Select(i => i.Category).ToList()
            });
        }

        public IActionResult Search(string q)
        {
            var courseViewModel = new CourseListViewModel()
            {
                Courses = _courseService.GetSearchResult(q)
            };

            return View(courseViewModel);
        }
    }
}
