using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace OnlineArtGallery.Models
{
    public static partial class Tools
    {
        private static readonly DBContext context = new();

        // User Type
        public static IEnumerable<UserType> GetUserTypeList() => context.UserTypes.ToList();
        public static string GetUsetType(int id) => context.UserTypes.Find(id).Name;

        // User
        public static IEnumerable<User> GetUserList() => context.Users.ToList();
        public static User GetUser(int id) => context.Users.Find(id);

        // Customer
        public static Customer GetCustomerFromUser(int userId) => (from a in context.Customers where a.UserId == userId select a).FirstOrDefault();

        // Artist
        public static Artist GetArtistFromUser(int userId) => (from a in context.Artists where a.UserId == userId select a).FirstOrDefault();

        // Art Category
        public static List<ArtCategory> GetArtCategoryList() => context.ArtCategories.ToList();

        //get User from Session
        public static User GetUserfromSession(string userString)
        {
            User user = new User();
            if (!String.IsNullOrEmpty(userString))
            {
                user = JsonConvert.DeserializeObject<User>(userString);    
            }
            return user;
        }

        //check artwork is get to auction yet
        public static bool CheckAuctionExist(int id)
        {
            return context.Auctions.Any(x => x.ArtworkId == id);
        }
    }
}
