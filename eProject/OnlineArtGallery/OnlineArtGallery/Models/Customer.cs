using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineArtGallery.Models
{
    [Table("Customer")]
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public string Interest { get; set; }
        public int UserId { get; set; }
        public bool Active { get; set; }
    }
}
