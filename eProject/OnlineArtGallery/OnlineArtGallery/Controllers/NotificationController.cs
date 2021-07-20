using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OnlineArtGallery.IService;
using OnlineArtGallery.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace OnlineArtGallery.Controllers
{
    public class NotificationController : Controller
    {
        INotiService _notiService = null;
        List<Notification> oNotifications = new List<Notification>();
        private static DBContext context;
        private static Timer timer;
        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            timer = new System.Timers.Timer(60 * 60 * 1000);
            // Hook up the Elapsed event for the timer. 
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            createTransactionNoti();
        }

        public NotificationController(INotiService notiService)
        {
            SetTimer();
            context ??= new DBContext();
            _notiService = notiService;
        }
        public IActionResult AllNotifications()
        {
            return View();
        }
        public JsonResult GetNotifications(bool bIsGetOnlyUnread = false)
        {
            string userString = HttpContext.Session.GetString("USER");

            if (!String.IsNullOrEmpty(userString))
            {
                var user = JsonConvert.DeserializeObject<User>(userString);
                oNotifications = new List<Notification>();
                oNotifications = _notiService.GetNotifications(Tools.GetCustomerfromSession(userString).UserId, bIsGetOnlyUnread);
            }
            
            return Json(oNotifications);

        }
        public static void createTransactionNoti()
        {
            List<Transaction> listPending = null;
            listPending = Tools.GetPendingTransaction();
            foreach(var item in listPending)
            {
                if (!checkExist(item.Id))
                {
                    context.Notifications.Add(new Notification()
                    {
                        Header = "You have a pending transaction. Please pay early!!",
                        IsRead = false,
                        Url = "/index/dashboard",
                        TransactionId = item.Id,
                        UserId = Tools.GetCustomerFromId(item.CustomerId).UserId,
                    });
                }
            }
            context.SaveChanges();
        }
        public IActionResult notiRead(int notiId)
        {
            if (context.Notifications.FirstOrDefault(n => n.Id == notiId) != null)
            {
                var noti = context.Notifications.FirstOrDefault(n => n.Id == notiId);
                noti.IsRead = true;
                context.Update(noti);
                context.SaveChanges();
            }
            return View();
        }
        public static bool checkExist(int transactionId)
        {
            if (context.Notifications.FirstOrDefault(n => n.TransactionId == transactionId) != null)
            {
                return true;
            }
            return false;
        }
    }
}
