
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
                    HttpContext.Session.SetString("USER", JsonConvert.SerializeObject(user));
                    string userType = context.UserTypes.FirstOrDefault(u => u.Id == user.UsertypeId).Name;
                    if (userType.Contains("Customer") || userType.Contains("Artist"))
                    {
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
    }
}
