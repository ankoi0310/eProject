using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineArtGallery.Models
{
    public class UserUpdate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public int UserId { get; set; }
    }
}
