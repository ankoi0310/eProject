using Microsoft.AspNetCore.Hosting;
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
    public class AuctionController : Controller
    {
        private readonly DBContext _context;
        private readonly IWebHostEnvironment _webHostEnvironmen;
        private Artist _artist;

        public AuctionController(IWebHostEnvironment webHostEnvironmen)
        {
            _context ??= new DBContext();
            _webHostEnvironmen = webHostEnvironmen;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: Auction
        public async Task<IActionResult> List()
        {
            _context.Artworks.ToList();
            string sessionString = HttpContext.Session.GetString("USER");
            _artist = Tools.GetArtistfromSession(sessionString);
            _context.ArtCategories.ToList();
            _context.Artists.ToList();

            ViewBag.AuctionRecords = _context.AuctionRecords.ToList();
            User user = _context.Users.Find(_artist.UserId);
            if (user != null && user.UsertypeId == 2)
            {
                ViewBag.User = user;
                return View(await _context.Auctions.Where(x => x.Artist.Id == _artist.Id).OrderByDescending(x => x.Id).ToListAsync());
            }
            else
            {
                ViewBag.User = JsonConvert.DeserializeObject<User>(sessionString);
                return View(await _context.Auctions.OrderByDescending(x => x.Id).ToListAsync());
            }
        }

        // GET: Auction/AddOrEdit
        // GET: Auction/AddOrEdit/5
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id, int artworkId, int artistId)
        {
            if (id == 0)
            {
                return base.View(new Auction { ArtworkId = artworkId, ArtistId = artistId });
            }
            else
            {
                var auction = await _context.Auctions.FindAsync(id);
                if (auction == null)
                {
                    return NotFound();
                }
                return View(auction);
            }
        }

        // POST: Auction/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, Auction auction)
        {
            if (ModelState.IsValid)
            {
                _context.Artworks.ToList();
                if (id == 0)
                {
                    _context.Add(auction);
                    await _context.SaveChangesAsync();
                }
                else
                {

                    try
                    {
                        _context.Auctions.Update(auction);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!AuctionExists(auction.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewString(this, "_ViewAll", _context.Auctions.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewString(this, "AddOrEdit", auction) });
        }

        // POST: Auction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _context.Artworks.ToList();
            var auction = await _context.Auctions.FindAsync(id);
            _context.Auctions.Remove(auction);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewString(this, "_ViewAll", _context.Auctions.ToList()) });
        }

        private bool AuctionExists(int id)
        {
            return _context.Auctions.Any(e => e.Id == id);
        }
    }
}
