
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
        private static User _user = null;
        public IndexController()
        {
            context ??= new DBContext();
        }

        public IActionResult Home()
        {
            //ViewBag.User = _user;
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
            context.Customers.ToList();
            ViewBag.Comments = context.MyGalleries.Where(x=>x.ArtworkId == id).ToList();
            ViewBag.ListArtCategory = context.ArtCategories.ToList();
            ViewBag.Artwork = context.Artworks.Find(id);
            //string sessionString = HttpContext.Session.GetString("USER");
            //Customer cus = Tools.GetCustomerfromSession(sessionString);
            //ViewBag.User = context.Users.Find(cus.UserId);
            ViewBag.User = _user;
            if (_user!= null && _user.UsertypeId == 3)
            {
                Customer cus = context.Customers.Where(x => x.UserId == _user.Id).SingleOrDefault();
                ViewBag.MyComment = context.MyGalleries.Where(x => x.ArtworkId == id && x.CustomerId == cus.Id).SingleOrDefault();
            }
            return View();
        }
        public IActionResult Auction()
        {
            context.Artists.ToList();
            context.Artworks.ToList();
            context.AuctionRecords.ToList();
            ViewBag.ListAuction = context.Auctions.ToList();
            return View();
        }
        public IActionResult AuctionDetail(int auctionId)
        {
            context.Artists.ToList();
            context.Customers.ToList();
            context.ArtCategories.ToList();
            context.Artworks.ToList();
            context.Customers.ToList();

            //string sessionString = HttpContext.Session.GetString("USER");
            //Customer cus = Tools.GetCustomerfromSession(sessionString);
            //ViewBag.User = context.Users.Find(cus.UserId);

            Auction auct = context.Auctions.Find(auctionId);
            ViewBag.AuctionRecords = context.AuctionRecords.Where(x => x.AuctionId == auct.Id).OrderByDescending(x => x.BidPrice).ToList();
            ViewBag.Auction = auct;
            ViewBag.Comments = context.MyGalleries.Where(x => x.ArtworkId == auct.ArtworkId).ToList();

            ViewBag.User = _user;
            if (_user != null && _user.UsertypeId == 3)
            {
                Customer cus = context.Customers.Where(x => x.UserId == _user.Id).SingleOrDefault();
                ViewBag.MyComment = context.MyGalleries.Where(x => x.ArtworkId == auct.ArtworkId && x.CustomerId == cus.Id).SingleOrDefault();
            }
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
                    _user = user;
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
        public IActionResult Artwork()
        {
            context.Artists.ToList();
            List<Auction> listAuction = context.Auctions.ToList();
            ViewBag.listAuction = context.Auctions.ToList();
            ViewBag.listArtCategory = context.ArtCategories.ToList();
            ViewBag.listArtwork = context.Artworks.Where(x => !listAuction.Select(y => y.ArtworkId).Contains(x.Id)).ToList();
            return View();
        }
        public IActionResult DashBoard()
        {
            Customer cus = null;
            cus = Tools.GetCustomerfromSession(HttpContext.Session.GetString("USER")) == null ? null : Tools.GetCustomerfromSession(HttpContext.Session.GetString("USER"));
            if (cus != null)
            {
                ViewBag.listTransaction = Tools.GetTransactionsFromCustomerId(cus.Id);
            }
            return View();
        }
        public IActionResult UserProfile()
        {
            return View();
        }
        public IActionResult MyBid()
        {
            context.Artworks.ToList();
            context.AuctionRecords.ToList();
            string sessionString = HttpContext.Session.GetString("USER");
            Customer cus = Tools.GetCustomerfromSession(sessionString);
            ViewBag.MyBid = context.Auctions.Where(x => x.AuctionRecords.Any(y => y.CustomerId == cus.Id)).ToList();
            return View();
        }
        public IActionResult WinningBid()
        {
            context.Artworks.ToList();
            DateTime now = DateTime.Now;
            string sessionString = HttpContext.Session.GetString("USER");
            Customer cus = Tools.GetCustomerfromSession(sessionString);
            List<AuctionRecord> ListAuctionRecord = context.AuctionRecords.Where(x => x.CustomerId == cus.Id).ToList();

            ViewBag.MyBid = context.Auctions.Where(x => x.AuctionRecords.Any(y => y.CustomerId == cus.Id) && DateTime.Compare(x.EndDay, now) <= 0).ToList();
            ViewBag.ListAuctionRecord = ListAuctionRecord;
            return View();
        }

        public IActionResult MyAlerts()
        {
            return View();
        }
        public IActionResult MyFavorite()
        {
            context.Artists.ToList();
            context.Artworks.ToList();
            string sessionString = HttpContext.Session.GetString("USER");
            Customer cus = Tools.GetCustomerfromSession(sessionString);
            List<MyGallery> listMyGallery = context.MyGalleries.Where(x => x.CustomerId == cus.Id && x.Favorite == true).ToList();
            ViewBag.listArtwork = context.Artworks.Where(x => listMyGallery.Select(y => y.ArtworkId).Contains(x.Id)).ToList();
            ViewBag.auction = context.Auctions.ToList();
            return View();
        }
        public IActionResult Referral()
        {
            return View();
        }
        public IActionResult Success()
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
            string sessionString = HttpContext.Session.GetString("USER");
            Customer cus = Tools.GetCustomerfromSession(sessionString);
            ViewBag.User = context.Users.Find(cus.UserId);
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

        [HttpPost]
        public IActionResult getAllGallery()
        {
            context.Artists.ToList();
            List<Artwork> aw = new List<Artwork>();
            var ListAuction = context.Auctions.ToList();
            aw = context.Artworks.Where(x => !ListAuction.Select(y => y.ArtworkId).Contains(x.Id)).ToList();
            return new JsonResult(aw);
        }

        public class carta
        {
            public string srcImg { get; set; }
            public string name { get; set; }
            public int price { get; set; }
            public string nameArtist { get; set; }
            public int artworkId { get; set; }
        }
        [HttpPost]
        public IActionResult PaymentSuccess(string cart, int IdUser, int TotalPrice, int TotalFee, int PaymentId, int StatusId)
        {
            var y = JsonConvert.DeserializeObject<List<carta>>(cart);
            Customer buyCus = context.Customers.Where(x => x.UserId == IdUser).SingleOrDefault();
            Transaction payments = new Transaction();
            payments.CustomerId = buyCus.Id;
            payments.TotalPrice = TotalPrice;
            payments.TotalFee = TotalFee;
            payments.PaymentId = PaymentId;
            payments.StatusId = StatusId;
            payments.Active = true;
            context.Transactions.Add(payments);
            context.SaveChanges();
            foreach (var item in y)
            {
                TransactionDetail detailTrans = new TransactionDetail();
                detailTrans.TransactionId = payments.Id;
                detailTrans.ArtworkId = item.artworkId;
                detailTrans.Price = item.price;
                detailTrans.Fee = item.price * 10 / 100; ;
                context.TransactionDetails.Add(detailTrans);
                Artwork aw = context.Artworks.Find(item.artworkId);
                aw.Active = false;
                context.Update(aw);
                context.SaveChanges();
            }
            return new JsonResult("success");
        }

        public IActionResult RateAndComment(int rate, string remark, int artworkId, int userId, int auctionId)
        {
            int CustomerId = context.Customers.Where(x => x.UserId == userId).SingleOrDefault().Id;
            if (CheckRemarkExist(artworkId, CustomerId))
            {
                MyGallery mg = context.MyGalleries.Where(x => x.ArtworkId == artworkId && x.CustomerId == CustomerId).SingleOrDefault();
                mg.Rate = rate;
                mg.Remark = remark;
                context.MyGalleries.Update(mg);
            }
            else
            {
                MyGallery mg = new MyGallery();
                mg.CustomerId = CustomerId;
                mg.ArtworkId = artworkId;
                mg.Rate = rate;
                mg.Remark = remark;
                context.MyGalleries.Add(mg);
            }
            context.SaveChanges();
            if (auctionId == 0)
            {
                return RedirectToAction("ArtworkDetail", new { id = artworkId });
            }
            else
            {
                return RedirectToAction("AuctionDetail", new { auctionId = auctionId });
            }
        }

        public string EditFavorite(int artworkId, int userId, int auctionId)
        {
            int CustomerId = context.Customers.Where(x => x.UserId == userId).SingleOrDefault().Id;
            string message = "";
            if (CheckRemarkExist(artworkId, CustomerId))
            {
                MyGallery mg = context.MyGalleries.Where(x => x.ArtworkId == artworkId && x.CustomerId == CustomerId).SingleOrDefault();
                bool currentFavorite = mg.Favorite;
                mg.Favorite = currentFavorite ? false : true;
                message = (mg.Favorite == true) ? "Remove from Favorite": "Add to Favorite";
                context.MyGalleries.Update(mg);
            }
            else
            {
                MyGallery mg = new MyGallery();
                mg.CustomerId = CustomerId;
                mg.ArtworkId = artworkId;
                mg.Favorite = true;
                message = "Remove from Favorite";
                context.MyGalleries.Add(mg);

            }
            context.SaveChanges();
            return message;
        }

        public bool CheckRemarkExist(int artworkId, int CustomerId)
        {
            return context.MyGalleries.Any(x => x.ArtworkId == artworkId && x.CustomerId == CustomerId);
        }
    }
}
