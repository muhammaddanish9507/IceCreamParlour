using IceCreamParlour.Models;
using IceCreamProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;

namespace IceCreamParlour.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AddDBContext _context;

        public HomeController(ILogger<HomeController> logger, AddDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Check if the session "UserSession" is null
            if (HttpContext.Session.GetString("UserSession1") == null)
            {
                // If session is null, redirect to the Login action in the Home controller
                return RedirectToAction("Login", "Users");
            }
            ViewBag.MySession1 = HttpContext.Session.GetString("UserSession1");
            // Session is active, proceed to the Index view
            return View();
        }
        public IActionResult Logout()
        {
            // Check if the session exists and remove it if it does
            if (HttpContext.Session.GetString("UserSession1") != null)
            {
                HttpContext.Session.Remove("UserSession1");
            }

            // Redirect to the login page after logging out
            return RedirectToAction("Login", "Users");
        }
        public async Task<IActionResult> Products()
        {
            if (HttpContext.Session.GetString("UserSession1") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            ViewBag.MySession1 = HttpContext.Session.GetString("UserSession1");
            return View(await _context.Books.ToListAsync());
        }

        public IActionResult AboutUs()
        {
            if (HttpContext.Session.GetString("UserSession1") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            ViewBag.MySession1 = HttpContext.Session.GetString("UserSession1");
            return View();
        }

        public IActionResult ContactUs()
        {
            if (HttpContext.Session.GetString("UserSession1") == null)
            {
                return RedirectToAction("Login", "Users ");
            }
            ViewBag.MySession1 = HttpContext.Session.GetString("UserSession1");
            return View();
        }

        public IActionResult Gallery()
        {
            if (HttpContext.Session.GetString("UserSession1") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            ViewBag.MySession1 = HttpContext.Session.GetString("UserSession1");
            return View();
        }

        public IActionResult Services()
        {
            if (HttpContext.Session.GetString("UserSession1") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            ViewBag.MySession1 = HttpContext.Session.GetString("UserSession1");
            return View();
        }

        public IActionResult Privacy()
        {
            if (HttpContext.Session.GetString("UserSession1") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            ViewBag.MySession1 = HttpContext.Session.GetString("UserSession1");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
