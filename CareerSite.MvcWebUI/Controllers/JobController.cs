using CareerSite.Business.Abstract;
using CareerSite.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CareerSite.MvcWebUI.Controllers
{
    public class JobController : Controller
    {
        private IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        public IActionResult Index()
        {
            var jobs = _jobService.GetByCategory(1);
            JobListViewModel model = new JobListViewModel
            {
                Jobs = jobs
            };

            return View(model);
        }
    }
}
