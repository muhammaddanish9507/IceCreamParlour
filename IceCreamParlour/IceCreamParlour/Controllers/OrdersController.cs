using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using IceCreamProject.Models;

namespace IceCreamParlour.Controllers
{
    public class OrdersController : Controller
    {
        private readonly AddDBContext _context;

        public OrdersController(AddDBContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("UserSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewBag.MySession = HttpContext.Session.GetString("UserSession");
            return View(await _context.Orders.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("UserSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewBag.MySession = HttpContext.Session.GetString("UserSession");
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.Order_ID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        // GET: Create Order
        // GET: Create Order
        public IActionResult Create(int? Product_ID)
        {
            // Check if the user session exists
            if (HttpContext.Session.GetString("UserSession1") == null)
            {
                // If not, redirect to the Login page
                return RedirectToAction("Login", "Users");
            }

            if (Product_ID == null)
            {
                return NotFound();
            }

            // Fetch product details from the database
            var product = _context.Books.FirstOrDefault(p => p.ID == Product_ID);

            if (product == null)
            {
                return NotFound();
            }

            // Create a new Order object and populate it with the product details
            var order = new Order
            {
                Product_ID = product.ID,
                Product_Name = product.B_name,
                Amount_Payable = product.Price, // Assuming your product has a Price field
                Quantity = 1 // Default quantity to 1, can be modified later by the user
            };

            return View(order);
        }

        // POST: Create Order
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order order)
        {
            // Check if the user session exists
            if (HttpContext.Session.GetString("UserSession1") == null)
            {
                // If not, redirect to the Login page
                return RedirectToAction("Login", "Users");
            }
            ViewBag.MySession1 = HttpContext.Session.GetString("UserSession1");

            if (ModelState.IsValid)
            {
                // Add the new order to the database
                _context.Orders.Add(order);
                _context.SaveChanges();

                // Redirect to the Payments page after successfully creating the order
                return RedirectToAction("Create", "Payments");
            }

            // If the model state is not valid, return the view with the current order object
            return View(order);
        }

        // GET: Order Confirmation
        public IActionResult orderconfirmation()
        {
            // Check if the user session exists
            if (HttpContext.Session.GetString("UserSession1") == null)
            {
                // If not, redirect to the Login page
                return RedirectToAction("Login", "Users");
            }

            return View();
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("UserSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewBag.MySession = HttpContext.Session.GetString("UserSession");
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Order_ID,Product_ID,Product_Name,Customer_Name,Email,Contact,Amount_Payable,Quantity")] Order order)
        {
            if (HttpContext.Session.GetString("UserSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewBag.MySession = HttpContext.Session.GetString("UserSession");
            if (id != order.Order_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Order_ID))
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
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("UserSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewBag.MySession = HttpContext.Session.GetString("UserSession");
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.Order_ID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("UserSession") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewBag.MySession = HttpContext.Session.GetString("UserSession");
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Confirmation(string otherParam, string anotherParam)
        {
            // code which shows user a confirmation message along with order id and amount payable
            ViewBag.id = otherParam;
            ViewBag.Amount = anotherParam;
            return View();
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Order_ID == id);
        }
    }
}
