using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public static User GetUser(int id) => context.Users.Find(id);

        // Art Category
        public static List<ArtCategory> GetArtCategoryList() => context.ArtCategories.ToList();

    }
}
