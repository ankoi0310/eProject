using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineArtGallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineArtGallery.Controllers
{
    public class CustomerController : Controller
    {
        private readonly DBContext _context;

        public CustomerController()
        {
            _context ??= new DBContext();
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: Customer
        public async Task<IActionResult> List()
        {
            return View(await _context.Customers.ToListAsync());
        }

        // GET: Customer/AddOrEdit
        // GET: Customer/AddOrEdit/5
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return base.View(new Customer());
            }
            else
            {
                var customer = await _context.Customers.FindAsync(id);
                if (customer == null)
                {
                    return NotFound();
                }
                return View(customer);
            }
        }

        // POST: Customer/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Id,Name,Gender,Birthday,Phone,Email,Address,Image,Interest,UserId,Active")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(customer);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        User user = _context.Users.Find(customer.UserId);
                        user.Active = customer.Active;
                        _context.Update(customer);
                        _context.Update(user);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CustomerExists(customer.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewString(this, "_ViewAll", _context.Customers.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewString(this, "AddOrEdit", customer) });
        }

        // POST: Member/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewString(this, "_ViewAll", _context.Customers.ToList()) });
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
