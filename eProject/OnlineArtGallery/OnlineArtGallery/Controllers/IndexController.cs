
﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineArtGallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineArtGallery.Controllers
{
    public class IndexController : Controller
    {

        private DBContext context;
        public IndexController()
        {
            context ??= new DBContext();
        }

        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Gallery()
        {
            context.Artists.ToList();
            ViewBag.ListArtCategory = context.ArtCategories.ToList();
            var ListAuction = context.Auctions.ToList();
            ViewBag.ListArtwork = context.Artworks.Where(x => !ListAuction.Select(y => y.ArtworkId).Contains(x.Id)).ToList();
            return View();
        }

        public IActionResult ArtworkDetail(int id)
        {
            context.Artists.ToList();
            ViewBag.ListArtCategory = context.ArtCategories.ToList();
            ViewBag.Artwork = context.Artworks.Find(id);
            return View();
        }
        public IActionResult Auction()
        {
            context.Artists.ToList();
            context.Artworks.ToList();
            ViewBag.ListAuction = context.Auctions.ToList();
            return View();
        }
        public IActionResult AuctionDetail(int auctionId)
        {
            context.Artists.ToList();
            context.Customers.ToList();
            context.ArtCategories.ToList();
            context.Artworks.ToList();
            string sessionString = HttpContext.Session.GetString("USER");
            Customer cus = Tools.GetCustomerfromSession(sessionString);
            ViewBag.User = context.Users.Find(cus.UserId);

            Auction auct = context.Auctions.Find(auctionId);
            ViewBag.AuctionRecords = context.AuctionRecords.Where(x => x.AuctionId == auct.Id).OrderByDescending(x => x.BidPrice).ToList();
            ViewBag.Auction = auct;
            return View();
        }

        public IActionResult AddBid(long bid, int auctionId, int userId)
        {
            AuctionRecord aucRecord = new AuctionRecord();
            aucRecord.BidPrice = bid;
            aucRecord.CustomerId = context.Customers.Where(x => x.UserId == userId).SingleOrDefault().Id;
            aucRecord.AuctionId = auctionId;
            aucRecord.Day = DateTime.Now;
            aucRecord.Qualified = true;
            context.AuctionRecords.Add(aucRecord);
            context.SaveChanges();
            return RedirectToAction("AuctionDetail", new { auctionId = auctionId });
        }

        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult AboutUs()
        {

            return View();
        }
        public async Task<IActionResult> SignUp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(int id, [Bind("Id,Username,Password,UsertypeId,Active")] User user)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    if (context.Users.FirstOrDefault(u => u.Username == user.Username) == null && user.Username != null)
                    {
                        user.Active = true;
                        context.Add(user);
                        await context.SaveChangesAsync();
                        if (user.UsertypeId == 3)
                        {
                            context.Add(new Customer() { UserId = user.Id }) ;
                        }
                        else
                        {
                            context.Add(new Artist() { UserId = user.Id });
                        }
                        await context.SaveChangesAsync();
                        ViewBag.Message = "Sign up successfully!!!";
                        return RedirectToAction("SignIn", "Index");
                    } else if (context.Users.FirstOrDefault(u => u.Username == user.Username) != null && user.Username != null)
                    {
                        ViewBag.Error = "Username existed!!!";
                    }
                   
                }
            }
            return View();
        }
        public IActionResult SignIn(string username, string password)
        {
            if (ModelState.IsValid)
            {
                if (context.Users.FirstOrDefault(u => u.Username.Equals(username) && u.Password.Equals(password)) != null && username != null)
                {
                    var user = context.Users.FirstOrDefault(u => u.Username.Equals(username) && u.Password.Equals(password));
                    if (user.UsertypeId != 1)
                    {
                        HttpContext.Session.SetString("USER", JsonConvert.SerializeObject(user.UsertypeId == 3 ? Tools.GetCustomerFromUser(user.Id) :
                            Tools.GetArtistFromUser(user.Id)));
                        return RedirectToAction("Home", "Index");
                    }
                    return RedirectToAction("Index", "Admin");
                }
                else if (context.Users.FirstOrDefault(u => u.Username.Equals(username) && u.Password.Equals(password)) == null && (username != null || password != null))
                {
                    ViewBag.Error = "Wrong username or password!!!";
                }
            }
            return View();
        }
        public IActionResult SignOut()
        {
            HttpContext.Session.Remove("USER");
            return RedirectToAction("Home", "Index");
        }
        public IActionResult DashBoard()
        {
            return View();
        }
        public IActionResult UserProfile()
        {
            return View();
        }
        public IActionResult MyBid()
        {
            return View();
        }
        public IActionResult WinningBid()
        {
            return View();
        }
        public IActionResult MyAlerts()
        {
            return View();
        }
        public IActionResult MyFavorite()
        {
            return View();
        }
        public IActionResult Referral()
        {
            return View();
        }
        
        public IActionResult Cart(List<int> listArtwork)
        {
            ViewBag.listToCart = listArtwork;
            return View();
        }
        public IActionResult Payment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult categoryGalery(int id)
        {
            context.Artists.ToList();
            List<Artwork> aw = new List<Artwork>();
            var ListAuction = context.Auctions.ToList();
            aw = context.Artworks.Where(p => p.ArtCategoryId == id && !ListAuction.Select(y => y.ArtworkId).Contains(p.Id)).ToList();
            return new JsonResult(aw);
        }
    }
}
