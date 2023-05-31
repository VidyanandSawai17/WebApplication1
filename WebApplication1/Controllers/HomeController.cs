using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;
        studform db;
        public HomeController(IConfiguration configuration)
        {
            this.configuration = configuration;
            db = new studform(this.configuration);
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;

        //}

        public IActionResult Index()
        {
            List<stud> logList = db.StudList();
            return View(logList);
        }

        public IActionResult Details(int Id)
        {
            try
            {
                stud student = db.StudDetails(Id);
                if (student != null)
                {
                    return View(student);
                }
                else
                {
                    return NotFound();

                }
            }
            catch
            {

                ViewBag.ErrorMessage = "Something went wrong";
                return View();
            }
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(int Id)
        {
            try
            {
                stud student = db.StudSearch(Id);
                if (student != null)
                {
                    return View("Details",student);
                }
                else
                {
                    return NotFound();

                }
            }
            catch
            {

                ViewBag.ErrorMessage = "Something went wrong";
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}