using CareerSite.Business.Abstract;
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
            return View();
        }
    }
}
