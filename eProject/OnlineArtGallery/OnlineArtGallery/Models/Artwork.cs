using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineArtGallery.Models
{
    [Table("Artwork")]
    public class Artwork
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }
        [Column("Name", TypeName = "nvarchar")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("CreateDay", TypeName = "date")]
        public DateTime CreateDay { get; set; }
        [Column("Quote", TypeName = "nvarchar")]
        public string Quote { get; set; }
        [Column("Description", TypeName = "nvarchar")]
        public string Description { get; set; }
        [Column("Image", TypeName = "nvarchar")]
        public string Image { get; set; }
        [Column("Size", TypeName = "nvarchar")]
        [StringLength(50)]
        public string Size { get; set; }
        [Column("DefaultPrice", TypeName = "bigint")]
        public Int64 DefautPrice { get; set; }
        [Column("ArtistId", TypeName = "int")]
        public int ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        public Artist Artist { get; set; }
        [Column("ArtCategoryId", TypeName = "int")]
        public int ArtCategoryId { get; set; }
        [ForeignKey("ArtCategoryId")]
        public ArtCategory ArtCategory { get; set; }
        [Column("Active", TypeName = "bit")]
        public bool Active { get; set; }

        [NotMapped]
        public FormFile FileImage { get; set; }

    }
}
