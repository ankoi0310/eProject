using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineArtGallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineArtGallery.Controllers
{
    public class StatusController : Controller
    {
        private readonly DBContext _context;

        public StatusController()
        {
            _context ??= new DBContext();
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: Status
        public async Task<IActionResult> List()
        {
            return View(await _context.Status.ToListAsync());
        }

        // GET: Status/AddOrEdit
        // GET: Status/AddOrEdit/5
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return base.View(new Status());
            }
            else
            {
                var status = await _context.Status.FindAsync(id);
                if (status == null)
                {
                    return NotFound();
                }
                return View(status);
            }
        }

        // POST: Status/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, Status status)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(status);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(status);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!StatusExists(status.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewString(this, "_ViewAll", _context.Status.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewString(this, "AddOrEdit", status) });
        }
        
        // POST: Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var status = await _context.Status.FindAsync(id);
            _context.Status.Remove(status);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewString(this, "_ViewAll", _context.Status.ToList()) });
        }

        private bool StatusExists(int id)
        {
            return _context.Status.Any(e => e.Id == id);
        }
    }
}
