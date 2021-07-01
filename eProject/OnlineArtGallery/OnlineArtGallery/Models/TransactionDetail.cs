using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineArtGallery.Models
{
    [Table("TransactionDetail")]
    public class TransactionDetail
    {
        [Key]
        [Column("TransactionId", TypeName = "int")]
        public int TransactionId { get; set; }
        [ForeignKey("TransactionId")]
        public Transaction Transaction { get; set; }
        [Key]
        [Column("ArtworkId", TypeName = "int")]
        public int ArtworkId { get; set; }
        [ForeignKey("ArtworkId")]
        public Artwork Artwork { get; set; }
        [Column("Price", TypeName = "bigint")]
        public Int64 Price { get; set; }
        [Column("Fee", TypeName = "bigint")]
        public Int64 Fee { get; set; }
    }
}
