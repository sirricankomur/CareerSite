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

        // localhost/products/telefon?page=1
        public IActionResult ListTr(string category, int page = 1)
        {
            const int pageSize = 6;
            var courseViewModel = new CourseListViewModel()
            {
                PageInfo = new PageInfo()
                {
                    TotalItems = _courseService.GetCountByCategoryTr(category),
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    CurrentCategory = category
                },
                Courses = _courseService.GetCoursesByCategoryTr(category, page, pageSize)
            };

            return View(courseViewModel);
        }

        public IActionResult ListEn(string category, int page = 1)
        {
            const int pageSize = 6;
            var courseViewModel = new CourseListViewModel()
            {
                PageInfo = new PageInfo()
                {
                    TotalItems = _courseService.GetCountByCategoryEn(category),
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    CurrentCategory = category
                },
                Courses = _courseService.GetCoursesByCategoryEn(category, page, pageSize)
            };

            return View(courseViewModel);
        }

        public IActionResult DetailsTr(string url)
        {
            if (url == null)
            {
                return NotFound();
            }
            Course course = _courseService.GetCourseDetailsTr(url);

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

        public IActionResult DetailsEn(string url)
        {
            if (url == null)
            {
                return NotFound();
            }
            Course course = _courseService.GetCourseDetailsEn(url);

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

        public IActionResult SearchTr(string q)
        {
            var courseViewModel = new CourseListViewModel()
            {
                Courses = _courseService.GetSearchResultTr(q)
            };

            return View(courseViewModel);
        }

        public IActionResult SearchEn(string q)
        {
            var courseViewModel = new CourseListViewModel()
            {
                Courses = _courseService.GetSearchResultEn(q)
            };

            return View(courseViewModel);
        }
    }
}
