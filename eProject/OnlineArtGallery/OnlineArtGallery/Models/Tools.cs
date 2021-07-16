using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Text;
using System.Security.Cryptography;
using System.Security;

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
        public static IEnumerable<Customer> GetCustomerList() => context.Customers.ToList();
        public static Customer GetCustomerFromUser(int userId) => (from a in context.Customers where a.UserId == userId select a).FirstOrDefault();

        // Artist
        public static IEnumerable<Artist> GetArtistList() => context.Artists.ToList();
        public static Artist GetArtistFromUser(int userId) => (from a in context.Artists where a.UserId == userId select a).FirstOrDefault();
        public static Artist GetArtistById(int id) => context.Artists.FirstOrDefault(a => a.Id == id);
        // Art Category
        public static List<ArtCategory> GetArtCategoryList() => context.ArtCategories.ToList();

        // Artwork
        public static Artwork GetArtworkById(int id) => context.Artworks.FirstOrDefault(a => a.Id == id);
        //get User from Session
        public static User GetUserfromSession(string userString)
        {
            User user = new();
            if (!String.IsNullOrEmpty(userString))
            {
                user = JsonConvert.DeserializeObject<User>(userString);    
            }
            return user;
        }

        //get Artist from Session
        public static Artist GetArtistfromSession(string sessionString)
        {
            Artist artist = new();
            if (!String.IsNullOrEmpty(sessionString))
            {
                artist = JsonConvert.DeserializeObject<Artist>(sessionString);
            }
            return artist;
        }

        public static Customer GetCustomerfromSession(string sessionString)
        {
            Customer cus = new();
            if (!String.IsNullOrEmpty(sessionString))
            {
                cus = JsonConvert.DeserializeObject<Customer>(sessionString);
            }
            return cus;
        }

        //check artwork is get to auction yet
        public static bool CheckAuctionExist(int id)
        {
            return context.Auctions.Any(x => x.ArtworkId == id);
        }

        /// <summary>
        /// Encrypts a given password and returns the encrypted data
        /// as a base64 string.
        /// </summary>
        /// <param name="plainText">An unencrypted string that needs
        /// to be secured.</param>
        /// <returns>A base64 encoded string that represents the encrypted
        /// binary data.
        /// </returns>
        /// <remarks>This solution is not really secure as we are
        /// keeping strings in memory. If runtime protection is essential,
        /// <see cref="SecureString"/> should be used.</remarks>
        /// <exception cref="ArgumentNullException">If <paramref name="plainText"/>
        /// is a null reference.</exception>
        public static string Encrypt(string plainText)
        {
            if (plainText == null) throw new ArgumentNullException(nameof(plainText));

            //encrypt data
            var data = Encoding.Unicode.GetBytes(plainText);
            byte[] encrypted = ProtectedData.Protect(data, null, DataProtectionScope.LocalMachine);

            //return as base64 string
            return Convert.ToBase64String(encrypted);
        }

        /// <summary>
        /// Decrypts a given string.
        /// </summary>
        /// <param name="cipher">A base64 encoded string that was created
        /// through the <see cref="Encrypt(string)"/> or
        /// <see cref="Encrypt(SecureString)"/> extension methods.</param>
        /// <returns>The decrypted string.</returns>
        /// <remarks>Keep in mind that the decrypted string remains in memory
        /// and makes your application vulnerable per se. If runtime protection
        /// is essential, <see cref="SecureString"/> should be used.</remarks>
        /// <exception cref="ArgumentNullException">If <paramref name="cipher"/>
        /// is a null reference.</exception>
        public static string Decrypt(string cipher)
        {
            if (cipher == null) throw new ArgumentNullException(nameof(cipher));

            //parse base64 string
            byte[] data = Convert.FromBase64String(cipher);

            //decrypt data
            byte[] decrypted = ProtectedData.Unprotect(data, null, DataProtectionScope.CurrentUser);
            return Encoding.Unicode.GetString(decrypted);
        }
    }
}
