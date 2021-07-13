using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineArtGallery.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineArtGallery.Controllers
{
    public class ExhibitionController : Controller
    {
        private readonly DBContext _context;
        private readonly IWebHostEnvironment _webHostEnvironmen;

        public ExhibitionController(IWebHostEnvironment webHostEnvironmen)
        {
            _context ??= new DBContext();
            _webHostEnvironmen = webHostEnvironmen;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: Exhibition
        public async Task<IActionResult> List()
        {
            return View(await _context.Exhibitions.ToListAsync());
        }

        // GET: Exhibition/AddOrEdit
        // GET: Exhibition/AddOrEdit/5
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return base.View(new Exhibition());
            }
            else
            {
                var exhibition = await _context.Exhibitions.FindAsync(id);
                if (exhibition == null)
                {
                    return NotFound();
                }
                return View(exhibition);
            }
        }

        // POST: Exhibition/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, Exhibition exhibition)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    List<IFormFile> files = Request.Form.Files.ToList();
                    foreach (FormFile formFile in files)
                    {
                        if (formFile.Length > 0)
                        {
                            exhibition.FileImage = formFile;
                        }
                    }
                    exhibition.Image = UploadImage(exhibition);
                    _context.Add(exhibition);
                    await _context.SaveChangesAsync();
                }
                else
                {

                    try
                    {
                        List<IFormFile> files = Request.Form.Files.ToList();
                        foreach (FormFile formFile in files)
                        {
                            if (formFile.Length > 0)
                            {
                                DeleteImage(exhibition);
                                exhibition.FileImage = formFile;
                                exhibition.Image = UploadImage(exhibition);
                            }
                        }

                        _context.Exhibitions.Update(exhibition);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ExhibitionExists(exhibition.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewString(this, "_ViewAll", _context.Exhibitions.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewString(this, "AddOrEdit", exhibition) });
        }

        // POST: Exhibition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exhibition = await _context.Exhibitions.FindAsync(id);
            _context.Exhibitions.Remove(exhibition);
            DeleteImage(exhibition);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewString(this, "_ViewAll", _context.Exhibitions.ToList()) });
        }

        private bool ExhibitionExists(int id)
        {
            return _context.Exhibitions.Any(e => e.Id == id);
        }

        private string UploadImage(Exhibition exhibition)
        {
            string fileName = null;
            if (exhibition.FileImage != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironmen.WebRootPath, "assets/img/exhibition");
                fileName = exhibition.Name + "-" + exhibition.FileImage.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    exhibition.FileImage.CopyTo(fileStream);
                }
            }
            return fileName;
        }

        private void DeleteImage(Exhibition exhibition)
        {
            if (exhibition.Id != 0)
            {
                string uploadDir = Path.Combine(_webHostEnvironmen.WebRootPath, "assets/img/exhibition");
                string filePath = Path.Combine(uploadDir, exhibition.Image);
                System.IO.File.Delete(filePath);
            }
        }
    }
}
