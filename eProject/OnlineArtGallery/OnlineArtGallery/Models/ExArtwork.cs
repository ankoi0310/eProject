using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineArtGallery.Models
{
    [Table("ExArtwork")]
    public class ExArtwork
    {
        [Key]
        [Column("ArtworkId", TypeName = "int")]
        public int ArtworkId { get; set; }
        [ForeignKey("ArtworkId")]
        public Artwork Artwork { get; set; }
        [Key]
        [Column("ExhibitionId", TypeName = "int")]
        public int ExhibitionId { get; set; }
        [ForeignKey("ExhibitionId")]
        public Exhibition Exhibition { get; set; }
        [Column("PostDay", TypeName = "date")]
        public DateTime PostDay { get; set; }
        [Column("Price", TypeName = "bigint")]
        public Int64 Price { get; set; }
        [Column("Sold", TypeName = "bit")]
        public bool Sold { get; set; }
    }
}
