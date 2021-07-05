using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineArtGallery.Controllers
{
    public class IndexController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Gallery()
        {
            return View();
        }
        public IActionResult Product()
        {
            return View();
        }
        public IActionResult ProductDetail()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult SignIn()
        {
            return View();
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
    }
}
