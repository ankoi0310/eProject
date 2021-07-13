﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OnlineArtGallery.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineArtGallery.Controllers
{
    public class ArtworkController : Controller
    {
        private readonly DBContext _context;
        private readonly IWebHostEnvironment _webHostEnvironmen;

        public ArtworkController(IWebHostEnvironment webHostEnvironmen)
        {
            _context ??= new DBContext();
            _webHostEnvironmen = webHostEnvironmen;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: Artwork
        public async Task<IActionResult> List()
        {
            _context.ArtCategories.ToList();
            _context.Artists.ToList();
            return View(await _context.Artworks.ToListAsync());
        }

        // GET: Artwork/AddOrEdit
        // GET: Artwork/AddOrEdit/5
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return base.View(new Artwork());
            }
            else
            {
                _context.ArtCategories.ToList();
                _context.Artists.ToList();
                var artwork = await _context.Artworks.FindAsync(id);
                if (artwork == null)
                {
                    return NotFound();
                }
                return View(artwork);
            }
        }

        // POST: Artwork/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, Artwork artwork)
        {
            if (ModelState.IsValid)
            {
                _context.ArtCategories.ToList();
                _context.Artists.ToList();
                if (id == 0)
                {
                    List<IFormFile> files = Request.Form.Files.ToList();
                    foreach (FormFile formFile in files)
                    {
                        if (formFile.Length > 0)
                        {
                            artwork.FileImage = formFile;
                        }
                    }
                    artwork.Image = UploadImage(artwork);
                    string userString = HttpContext.Session.GetString("USER");
                    if (!String.IsNullOrEmpty(userString))
                    {
                        var user = JsonConvert.DeserializeObject<User>(userString);
                        artwork.ArtistId = _context.Artists.Where(x => x.UserId == user.Id).SingleOrDefault().Id;
                    }
                    artwork.CreateDay = DateTime.Now;
                    _context.Add(artwork);
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
                                DeleteImage(artwork);
                                artwork.FileImage = formFile;
                                artwork.Image = UploadImage(artwork);
                            }
                        }
                        _context.Artworks.Update(artwork);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ArtworkExists(artwork.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewString(this, "_ViewAll", _context.Artworks.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewString(this, "AddOrEdit", artwork) });
        }

        // POST: Artwork/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artwork = await _context.Artworks.FindAsync(id);
            _context.Artworks.Remove(artwork);
            DeleteImage(artwork);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewString(this, "_ViewAll", _context.Artworks.ToList()) });
        }

        private bool ArtworkExists(int id)
        {
            return _context.Artworks.Any(e => e.Id == id);
        }

        private string UploadImage(Artwork artwork)
        {
            string fileName = null;
            if (artwork.FileImage != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironmen.WebRootPath, "assets/img/artwork");
                fileName = artwork.Name + "-" + artwork.FileImage.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    artwork.FileImage.CopyTo(fileStream);
                }
            }
            return fileName;
        }

        private void DeleteImage(Artwork artwork)
        {
            if (artwork.Id != 0)
            {
                string uploadDir = Path.Combine(_webHostEnvironmen.WebRootPath, "assets/img/artwork");
                string filePath = Path.Combine(uploadDir, artwork.Image);
                System.IO.File.Delete(filePath);
            }
        }
    }
}
