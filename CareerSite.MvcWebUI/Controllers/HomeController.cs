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
        private readonly ILogger<HomeController> _logger;
        private ICategoryService _categoryService;

 

        public HomeController(ILogger<HomeController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;

        }

        public IActionResult Index()
        {
            var model = new CategoryListViewModel
            {

                Categories = _categoryService.GetAll(),
                CurrentCategory = Convert.ToInt32(HttpContext.Request.Query["category"])
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
