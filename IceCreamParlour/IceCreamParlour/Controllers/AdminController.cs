using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using IceCreamProject.Models;
using System.Linq;

namespace IceCreamProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly AddDBContext _context;

        public AdminController(AddDBContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            // code that takes us to the login page
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Admin user)
        {
            var myUser = _context.Admins.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);

            if (myUser != null)
            {
                HttpContext.Session.SetString("UserSession", myUser.UserName);
                // Authentication successful, redirect to admin dashboard or perform other actions
                return RedirectToAction("Index");
            }
            else
            {
                // Authentication failed, return to login page with error message
                ViewBag.ErrorMessage = "Invalid username or password.";
                return View();
            }
        }
        public IActionResult Logout()
        {
            // Check if the session exists and remove it if it does
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                HttpContext.Session.Remove("UserSession");
            }

            // Redirect to the login page after logging out
            return RedirectToAction("Login");
        }


        public IActionResult Index()
        {
            // Check if the session exists
            if (HttpContext.Session.GetString("UserSession") == null)
            {
                // If the session is null (user not logged in), redirect to Login page
                return RedirectToAction("Login");
            }
            ViewBag.MySession = HttpContext.Session.GetString("UserSession");
            // If the session exists, proceed to the Admin Dashboard (Index)
            return View();
        }
    }
}
