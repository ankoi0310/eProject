
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OnlineArtGallery.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OnlineArtGallery.Controllers
{
    public class IndexController : Controller
    {

        private DBContext context;
        private readonly IWebHostEnvironment _webHostEnvironmen;
        private static User _user = null;
        public IndexController(IWebHostEnvironment webHostEnvironmen)
        {
            context ??= new DBContext();
            _webHostEnvironmen = webHostEnvironmen;
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
            ViewBag.ListArtwork = context.Artworks.Where(x => !ListAuction.Select(y => y.ArtworkId).Contains(x.Id) && x.Active == true).ToList();
            return View();
        }

        public IActionResult ArtworkDetail(int id)
        {
            context.Artists.ToList();
            context.Customers.ToList();
            ViewBag.Comments = context.MyGalleries.Where(x => x.ArtworkId == id).ToList();
            ViewBag.ListArtCategory = context.ArtCategories.ToList();
            ViewBag.Artwork = context.Artworks.Find(id);
            //string sessionString = HttpContext.Session.GetString("USER");
            //Customer cus = Tools.GetCustomerfromSession(sessionString);
            //ViewBag.User = context.Users.Find(cus.UserId);
            ViewBag.User = _user;
            if (_user != null && _user.UsertypeId == 3)
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
            ViewBag.ListAuction = context.Auctions.Where(x=>x.Artwork.Active == true).ToList();
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
                            context.Add(new Customer() { UserId = user.Id });
                        }
                        else
                        {
                            context.Add(new Artist() { UserId = user.Id });
                        }
                        await context.SaveChangesAsync();
                        ViewBag.Message = "Sign up successfully!!!";
                        return RedirectToAction("SignIn", "Index");
                    }
                    else if (context.Users.FirstOrDefault(u => u.Username == user.Username) != null && user.Username != null)
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
                //var user = Tools.GetUser(username, password);
                var user = context.Users.FirstOrDefault(u => u.Username== username && u.Password == password);
                _user = user;
                if (user != null)
                {
                    if (user.UsertypeId != 1)
                    {
                        if (user.UsertypeId == 3)
                        {
                            //HttpContext.Session.SetString("USER", JsonConvert.SerializeObject(Tools.GetCustomerFromUser(user.Id)));
                            HttpContext.Session.SetString("USER", JsonConvert.SerializeObject(context.Customers.Where(x => x.UserId == user.Id).SingleOrDefault()));
                            return RedirectToAction("Home", "Index");
                        } else
                        {
                            //HttpContext.Session.SetString("USER", JsonConvert.SerializeObject(Tools.GetArtistFromUser(user.Id)));
                            HttpContext.Session.SetString("USER", JsonConvert.SerializeObject(context.Artists.Where(x=>x.UserId == user.Id).SingleOrDefault()));
                            return RedirectToAction("Home", "Index");
                        }
                    }
                    HttpContext.Session.SetString("USER", JsonConvert.SerializeObject(user));
                    return RedirectToAction("Index", "Admin");
                }
                else if (username != null || password != null)
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
            ViewBag.listArtwork = context.Artworks.Where(x => !listAuction.Select(y => y.ArtworkId).Contains(x.Id) && x.Active == true).ToList();
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
            if (HttpContext.Session.GetString("USER") == null)
            {
                return RedirectToAction("Home", "Index");
            }
            return View();
        }

        [NoDirectAccess]
        public IActionResult AddOrEdit()
        {
            UserUpdate userUpdate = JsonConvert.DeserializeObject<UserUpdate>(HttpContext.Session.GetString("USER"));
            return View(userUpdate);
        }

        //[Bind("Id,Name,Gender,Birthday,Phone,Email,Address,UserId")]
        public async Task<IActionResult> Update( UserUpdate userUpdate)
        {
            if (ModelState.IsValid)
            {
                List<IFormFile> files = Request.Form.Files.ToList();
                foreach (FormFile formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        if (!string.IsNullOrEmpty(userUpdate.Image))
                        {
                            DeleteImage(userUpdate);
                        }
                        userUpdate.FileImage = formFile;
                        userUpdate.Image = UploadImage(userUpdate);
                    }
                }

                if (Tools.GetUser(userUpdate.UserId).UsertypeId == 3)
                {

                    Customer oldCustomer = await context.Customers.FindAsync(userUpdate.Id);
                    oldCustomer.Name = userUpdate.Name;
                    oldCustomer.Gender = userUpdate.Gender;
                    oldCustomer.Birthday = userUpdate.Birthday;
                    oldCustomer.Address = userUpdate.Address;
                    oldCustomer.Phone = userUpdate.Phone;
                    oldCustomer.Email = userUpdate.Email;
                    oldCustomer.Image = userUpdate.Image;
                    HttpContext.Session.SetString("USER", JsonConvert.SerializeObject(oldCustomer));
                    context.Update(oldCustomer);
                }
                else if (Tools.GetUser(userUpdate.UserId).UsertypeId == 2)
                {
                    Artist oldArtist = await context.Artists.FindAsync(userUpdate.Id);
                    oldArtist.Name = userUpdate.Name;
                    oldArtist.Gender = userUpdate.Gender;
                    oldArtist.Birthday = userUpdate.Birthday;
                    oldArtist.Address = userUpdate.Address;
                    oldArtist.Phone = userUpdate.Phone;
                    oldArtist.Email = userUpdate.Email;
                    oldArtist.Image = userUpdate.Image;
                    //if (!string.IsNullOrEmpty(userUpdate.Image))
                    //{
                        
                    //}
                    HttpContext.Session.SetString("USER", JsonConvert.SerializeObject(oldArtist));
                    context.Update(oldArtist);
                }
                await context.SaveChangesAsync();
                return Json(new { isValid = true, html = Helper.RenderRazorViewString(this, "userprofile") });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewString(this, "AddOrEdit", userUpdate) });
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
            ViewBag.Customer = cus;
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

        public IActionResult PaymentWinningBid(int artworkId, int customerId, int winningBid)
        {
            Customer cus = context.Customers.Find(customerId);
            TransactionDetail transDetail = new TransactionDetail();
            transDetail.ArtworkId = artworkId;
            transDetail.Price = winningBid;
            transDetail.Fee = winningBid * 10 / 100;
            ViewBag.TransDetail = transDetail;
            ViewBag.User = context.Users.Find(cus.UserId);
            ViewBag.Customer = cus;
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

        [HttpPost]
        public IActionResult sortBy(string a)
        {
            context.Artists.ToList();
            List<Auction> listAuction = context.Auctions.ToList();
            listAuction = context.Auctions.ToList();
            List<Artwork> aw = new List<Artwork>();
            if (a == "Price2")
            {
                aw = context.Artworks.Where(x => !listAuction.Select(y => y.ArtworkId).Contains(x.Id) && x.Active == true).OrderByDescending(x => x.DefautPrice).ToList();
            }
            else if (a == "Price1")
            {
                aw = context.Artworks.Where(x => !listAuction.Select(y => y.ArtworkId).Contains(x.Id) && x.Active == true).OrderBy(x => x.Name).ToList();
            }
            else if (a == "Name")
            {
                aw = context.Artworks.Where(x => !listAuction.Select(y => y.ArtworkId).Contains(x.Id) && x.Active == true).OrderBy(x => x.Name).ToList();
            }
            else
            {
                aw = context.Artworks.Where(x => !listAuction.Select(y => y.ArtworkId).Contains(x.Id) && x.Active == true).ToList();
            }

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
            payments.Date = DateTime.Now;
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

        public IActionResult PaymentSuccessBid(int artworkId, int customerId, long totalPrice, long totalFee, int paymentId, int statusId)
        {
            Transaction payments = new Transaction();
            payments.CustomerId = customerId;
            payments.Date = DateTime.Now;
            payments.TotalPrice = totalPrice;
            payments.TotalFee = totalFee;
            payments.PaymentId = paymentId;
            payments.StatusId = statusId;
            payments.Active = true;
            context.Transactions.Add(payments);
            context.SaveChanges();

            TransactionDetail detailTrans = new TransactionDetail();
            detailTrans.TransactionId = payments.Id;
            detailTrans.ArtworkId = artworkId;
            detailTrans.Price = totalPrice;
            detailTrans.Fee = totalFee;
            Artwork aw = context.Artworks.Find(artworkId);
            Auction au = context.Auctions.Where(x=>x.ArtworkId==artworkId).SingleOrDefault();
            au.Active = false;
            aw.Active = false;
            context.Update(aw);
            context.SaveChanges();
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
                message = (mg.Favorite == true) ? "Remove from Favorite" : "Add to Favorite";
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

        private string UploadImage(UserUpdate userUpdate)
        {
            string fileName = null;
            if (userUpdate.FileImage != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironmen.WebRootPath, "assets/img/userImage");
                fileName = Regex.Replace(userUpdate.Name, @"\s+", "") + "-" + userUpdate.FileImage.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    userUpdate.FileImage.CopyTo(fileStream);
                }
            }
            return fileName;
        }

        private void DeleteImage(UserUpdate userUpdate)
        {
            string uploadDir = Path.Combine(_webHostEnvironmen.WebRootPath, "assets/img/userImage");
            string filePath = Path.Combine(uploadDir, userUpdate.Image);
            System.IO.File.Delete(filePath);

        }
    }
}
