using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OnlineArtGallery.IService;
using OnlineArtGallery.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineArtGallery.Service
{
    public class NotiService: INotiService
    {
        List<Notification> Notifications = new List<Notification>();
        List<Notification> INotiService.GetNotifications(int nToUserId, bool bIsOnlyUnread)
        {
            Notifications = new List<Notification>();
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);

            var configuration = builder.Build();

            using (IDbConnection con = new SqlConnection(configuration.GetConnectionString("MyConnection").ToString())) 
            {
                if (con.State == ConnectionState.Closed) con.Open();
                var oNotis = con.Query<Notification>("SELECT * FROM Notification WHERE UserId=" + nToUserId).ToList();
                if (oNotis != null && oNotis.Count() > 0)
                {
                    Notifications = oNotis;
                }
                return Notifications;
            }
        }
    }
}
