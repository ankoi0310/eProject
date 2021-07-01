using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineArtGallery.Models
{
    [Table("Auction")]
    public class Auction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }
        [Column("ArtworkId", TypeName = "int")]
        public int ArtworkId { get; set; }
        [Column("BeginDay", TypeName = "date")]
        public DateTime BeginDay { get; set; }
        [Column("EndDay", TypeName = "date")]
        public DateTime EndDay { get; set; }
        [Column("ReservePrice", TypeName = "bigint")]
        public Int64 ReservePrice { get; set; }
        [Column("StepPrice", TypeName = "bigint")]
        public Int64 StepPrice { get; set; }
        [Column("Description", TypeName = "nvarchar")]
        public string Description { get; set; }
        [Column("ArtistId", TypeName = "int")]
        public int ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        public Artist Artist { get; set; }
        [Column("Active", TypeName = "bit")]
        public bool Active { get; set; }

    }
}
