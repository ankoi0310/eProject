using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineArtGallery.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Dashboard";
            if (HttpContext.Session.GetString("USER") == null)
            {
                return RedirectToAction("signin", "index", null);
            }
            return View();
        }
        public IActionResult Form()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
