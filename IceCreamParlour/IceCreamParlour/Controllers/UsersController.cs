using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IceCreamProject.Models;
using Microsoft.Data.SqlClient;

namespace IceCreamParlour.Controllers
{
    public class UsersController : Controller
    {
        private readonly AddDBContext _context;

        public UsersController(AddDBContext context)
        {
            _context = context;
        }
        public IActionResult Confirmation(string otherParam, string anotherParam)
        {
            // code that shows user id and amount payable after user registration
            ViewBag.id = otherParam;
            if (string.Equals(anotherParam, "Monthly") || string.Equals(anotherParam, "monthly"))
            {
                ViewBag.Amount = 15;

            }
            else if (string.Equals(anotherParam, "Yearly") || string.Equals(anotherParam, "yearly"))
            {
                ViewBag.Amount = 150;
            }

            return View();

        }
        public IActionResult Login()
        {
            // Code that takes the user to the login page
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string password)
        {
            // Attempt to find the user in the database based on the provided email and password
            var myUser = _context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);

            if (myUser != null)
            {
                // If the user exists, store their email in the session
                HttpContext.Session.SetString("UserSession1", myUser.Email);

                // Authentication successful, redirect to the user dashboard or any other page
                return RedirectToAction("index", "Home");
            }
            else
            {
                // Authentication failed, return to the login page with an error message
                ViewBag.ErrorMessage = "Invalid email or password.";
                return View();
            }
        }

        // GET: Users
        // GET: Users
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("UserSession") == null)
            {
                return RedirectToAction("Login", "Users");
            }

            ViewBag.MySession = HttpContext.Session.GetString("UserSession");
            return View(await _context.Users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("UserSession") == null)
            {
                return RedirectToAction("Login", "Users");
            }

            ViewBag.MySession = HttpContext.Session.GetString("UserSession");

            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,UserName,Password,Email,active,Payment")] Users users)
        {
            if (ModelState.IsValid)
            {
                _context.Add(users);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login");
            }
            return View(users);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("UserSession") == null)
            {
                return RedirectToAction("Login", "Users");
            }

            ViewBag.MySession = HttpContext.Session.GetString("UserSession");

            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserID,UserName,Password,Email,active,Payment")] Users users)
        {
            if (HttpContext.Session.GetString("UserSession") == null)
            {
                return RedirectToAction("Login", "Users");
            }

            ViewBag.MySession = HttpContext.Session.GetString("UserSession");

            if (id != users.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(users);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(users.UserID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(users);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("UserSession") == null)
            {
                return RedirectToAction("Login", "Users");
            }

            ViewBag.MySession = HttpContext.Session.GetString("UserSession");

            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("UserSession") == null)
            {
                return RedirectToAction("Login", "Users");
            }

            ViewBag.MySession = HttpContext.Session.GetString("UserSession");

            var users = await _context.Users.FindAsync(id);
            if (users != null)
            {
                _context.Users.Remove(users);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.UserID == id);
        }
    }
}