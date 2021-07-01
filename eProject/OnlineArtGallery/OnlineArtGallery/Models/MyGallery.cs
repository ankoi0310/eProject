using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineArtGallery.Models
{
    [Table("MyGallery")]
    public class MyGallery
    {
        [Key]
        [Column("CustomerId", TypeName = "int")]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        [Key]
        [Column("ArtworkId", TypeName = "int")]
        public int ArtworkId { get; set; }
        [ForeignKey("ArtworkId")]
        public Artwork Artwork { get; set; }
        [Column("Rate", TypeName = "int")]
        public int Rate { get; set; }
        [Column("Remark", TypeName = "nvarchar")]
        public string Remark { get; set; }
        [Column("Favorite", TypeName = "bit")]
        public bool Favorite { get; set; }
    }
}
