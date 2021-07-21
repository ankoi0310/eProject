using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineArtGallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineArtGallery.Controllers
{
    public class ReportController : Controller
    {
        private readonly DBContext _context;

        public ReportController()
        {
            _context ??= new DBContext();
        }

        public IActionResult Index()
        {
            return View();
        }

        // Artwork inventory
        public async Task<IActionResult> ListArtwork()
        {
            _context.Artists.ToList();
            _context.ArtCategories.ToList();
            ViewBag.Rate = _context.MyGalleries.ToList();
            return View( await _context.Artworks.ToListAsync());
        }

        //winningBid Report
        public async Task<IActionResult> ListAuctionBid()
        {
            _context.Artists.ToList();
            _context.Artworks.ToList();
            var auctionRecords = _context.AuctionRecords.ToList();
            ViewBag.auctionRecords = auctionRecords;
            return View( await _context.Auctions.Where(x=> auctionRecords.Select(y=>y.AuctionId).Contains(x.Id)).ToListAsync());
        }

        //winningBid Report
        public async Task<IActionResult> ListTransaction()
        {
            _context.Artworks.ToList();
            _context.Customers.ToList();
            _context.Status.ToList();
            _context.Payments.ToList();
            _context.TransactionDetails.ToList();
            return View(await _context.Transactions.ToListAsync());
        }
    }
}
