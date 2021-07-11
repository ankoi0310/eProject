using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineArtGallery.Models
{
    [Table("User")]
    public class User
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Column("Id", TypeName = "int")]
        public int Id { get; set; }
        //[Column("Username", TypeName = "nvarchar")]
        //[StringLength(50)]
        public string Username { get; set; }
        //[Column("Password", TypeName = "nvarchar")]
        //[StringLength(50)]
        public string Password { get; set; }
        //[Column("UsertypeId", TypeName = "int")]
        public int UsertypeId { get; set; }
        //[ForeignKey("UsertypeId")]
        //public UserType UserType { get; set; }
        //[Column("Active", TypeName = "bit")]
        public bool Active { get; set; }
    }
}
