using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserLog _userLog;

        public LoginController(UserLog userLog)
        {
            _userLog = userLog;
        }

        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

      
        [HttpPost]
        public IActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                User log = new User
                {
                    Username = model.Username,
                    Password = model.Password
                };

                if (_userLog.Login(log))
                {
                   
                    return RedirectToAction("Index", "Home");
                }
                
                ModelState.AddModelError("", "Invalid username or password");
            }
            return View(model);
        }
    }
}