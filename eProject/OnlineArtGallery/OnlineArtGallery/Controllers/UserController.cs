using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineArtGallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineArtGallery.Controllers
{
    public class UserController : Controller
    {
        private readonly DBContext _context;

        public UserController()
        {
            _context ??= new DBContext();
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: User
        public async Task<IActionResult> List()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: User/AddOrEdit
        // GET: User/AddOrEdit/5
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return base.View(new User());
            }
            else
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                return View(user);
            }
        }

        // POST: User/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Id,Username,Password,UsertypeId,Active")] User user)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    if (user.UsertypeId == 3)
                    {
                        _context.Add(new Customer() { UserId = user.Id });
                    }
                    else
                    {
                        _context.Add(new Artist() { UserId = user.Id });
                    }
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(user);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!UserExists(user.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewString(this, "_ViewAll", _context.Users.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewString(this, "AddOrEdit", user) });
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewString(this, "_ViewAll", _context.Users.ToList()) });
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
