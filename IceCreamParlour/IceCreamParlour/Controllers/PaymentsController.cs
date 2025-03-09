using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;  // Import for session management
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IceCreamParlour.Models;
using IceCreamProject.Models;

namespace IceCreamParlour.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly AddDBContext _context;

        public PaymentsController(AddDBContext context)
        {
            _context = context;
        }

        // GET: Payments
        public async Task<IActionResult> Index()
        {
            // Check if UserSession exists in the session
            if (HttpContext.Session.GetString("UserSession") == null)
            {
                // If session doesn't exist, redirect to the Admin Login page
                return RedirectToAction("Login", "Admin");
            }

            // Retrieve the session value and store it in ViewBag for use in the view
            ViewBag.MySession = HttpContext.Session.GetString("UserSession");

            return View(await _context.Payments.ToListAsync());
        }

        // GET: Payments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.MySession = HttpContext.Session.GetString("UserSession");
            if (id == null)
            {
                return NotFound();
            }

            var payments = await _context.Payments
                .FirstOrDefaultAsync(m => m.PaymentID == id);
            if (payments == null)
            {
                return NotFound();
            }

            return View(payments);
        }

        // GET: Payments/Create
        // GET: Payments/Create
        public IActionResult Create()
        {
            // Check if the user session exists
            if (HttpContext.Session.GetString("UserSession1") == null)
            {
                // If not, redirect to the Login page
                return RedirectToAction("Login", "Users");
            }

            return View();
        }

        // POST: Payments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentID,NameOnCard,CardNumber,CVV,ExpirationDate")] Payments payments)
        {
            // Check if the user session exists
            if (HttpContext.Session.GetString("UserSession1") == null)
            {
                // If not, redirect to the Login page
                return RedirectToAction("Login", "Users");
            }
            ViewBag.MySession1 = HttpContext.Session.GetString("UserSession1");
            // Proceed with the logic if the session exists
            if (ModelState.IsValid)
            {
                _context.Add(payments);
                await _context.SaveChangesAsync();
                return RedirectToAction("orderconfirmation", "Orders");
            }

            return View(payments);
        }


        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.MySession = HttpContext.Session.GetString("UserSession");
            if (id == null)
            {
                return NotFound();
            }

            var payments = await _context.Payments.FindAsync(id);
            if (payments == null)
            {
                return NotFound();
            }
            return View(payments);
        }

        // POST: Payments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentID,NameOnCard,CardNumber,CVV,ExpirationDate")] Payments payments)
        {
            ViewBag.MySession = HttpContext.Session.GetString("UserSession");
            if (id != payments.PaymentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentsExists(payments.PaymentID))
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
            return View(payments);
        }

        // GET: Payments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.MySession = HttpContext.Session.GetString("UserSession");
            if (id == null)
            {
                return NotFound();
            }

            var payments = await _context.Payments
                .FirstOrDefaultAsync(m => m.PaymentID == id);
            if (payments == null)
            {
                return NotFound();
            }

            return View(payments);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewBag.MySession = HttpContext.Session.GetString("UserSession");
            var payments = await _context.Payments.FindAsync(id);
            if (payments != null)
            {
                _context.Payments.Remove(payments);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentsExists(int id)
        {
            return _context.Payments.Any(e => e.PaymentID == id);
        }
    }
}
