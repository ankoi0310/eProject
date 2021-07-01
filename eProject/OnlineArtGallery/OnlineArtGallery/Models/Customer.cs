using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineArtGallery.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }
        [Column("Name", TypeName = "nvarchar")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("Gender", TypeName = "bit")]
        public bool Gender { get; set; }
        [Column("Birthday", TypeName = "date")]
        public DateTime Birthday { get; set; }
        [Column("Phone", TypeName = "nvarchar")]
        [StringLength(50)]
        public string Phone { get; set; }
        [Column("Email", TypeName = "nvarchar")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column("Address", TypeName = "nvarchar")]
        public string Address { get; set; }
        [Column("Image", TypeName = "nvarchar")]
        public string Image { get; set; }
        [Column("Interest", TypeName = "nvarchar")]
        public string Interest { get; set; }
        [Column("BankAccount", TypeName = "nvarchar")]
        [StringLength(50)]
        public string BankAccount { get; set; }
        [Column("BankName", TypeName = "nvarchar")]
        [StringLength(50)]
        public string BankName { get; set; }
        [Column("UserId", TypeName = "int")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [Column("Active", TypeName = "bit")]
        public bool Active { get; set; }
    }
}
