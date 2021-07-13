using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineArtGallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineArtGallery.Controllers
{
    public class ArtCategoryController : Controller
    {
        private readonly DBContext _context;

        public ArtCategoryController()
        {
            _context ??= new DBContext();
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: ArtCategory
        public async Task<IActionResult> List()
        {
            return View(await _context.ArtCategories.ToListAsync());
        }

        // GET: ArtCategory/AddOrEdit
        // GET: ArtCategory/AddOrEdit/5
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return base.View(new ArtCategory());
            }
            else
            {
                var artCate = await _context.ArtCategories.FindAsync(id);
                if (artCate == null)
                {
                    return NotFound();
                }
                return View(artCate);
            }
        }

        // POST: ArtCategory/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, ArtCategory artCate)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(artCate);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(artCate);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ArtCategoryExists(artCate.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewString(this, "_ViewAll", _context.ArtCategories.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewString(this, "AddOrEdit", artCate) });
        }
        
        // POST: ArtCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artCate = await _context.ArtCategories.FindAsync(id);
            _context.ArtCategories.Remove(artCate);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewString(this, "_ViewAll", _context.ArtCategories.ToList()) });
        }

        private bool ArtCategoryExists(int id)
        {
            return _context.ArtCategories.Any(e => e.Id == id);
        }
    }
}
