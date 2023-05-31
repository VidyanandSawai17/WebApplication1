using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class studController : Controller
    {
        private readonly IConfiguration configuration;
        studform db;
        public studController(IConfiguration configuration)
        {
            this.configuration = configuration;
            db = new studform(this.configuration);
        }

        public IActionResult Index()
        {
           List<stud> logList = db.StudList();
           return View(logList);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(stud student)
        {
            try
            {
                int res = db.AddStud(student);
                if (res > 0)
                {
                    ViewBag.SuccessMessage = "Submitted Sucessfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error("Something went wrong");
                    return View();

                }
            }
            catch
            {

                ViewBag.ErrorMessage = "Something went wrong";
                return View();
            }
        }

        public IActionResult Edit(int Id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(stud student)
        {
            try
            {
                int res = db.EditStud(student);
                if (res > 0)
                {
                    ViewBag.SuccessMessage = "Submitted Sucessfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error("Something went wrong");
                    return View();

                }
            }
            catch
            {

                ViewBag.ErrorMessage = "Something went wrong";
                return View();
            }
        }

        public IActionResult Delete(int Id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(stud student)
        {
            try
            {
                int res = db.DeleteStud(student);
                if (res > 0)
                {
                    ViewBag.SuccessMessage = "Sucessfully Deleted";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error("Something went wrong");
                    return View();

                }
            }
            catch
            {

                ViewBag.ErrorMessage = "Something went wrong";
                return View();
            }
        }
    }
}
