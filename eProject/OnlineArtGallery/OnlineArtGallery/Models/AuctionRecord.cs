using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineArtGallery.Models
{
    [Table("AuctionRecord")]
    public class AuctionRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }
        [Column("AuctionId", TypeName = "int")]
        public int AuctionId { get; set; }
        [ForeignKey("AuctionId")]
        public Auction Auction { get; set; }
        [Column("CustomerId", TypeName = "int")]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        [Column("BidPrice", TypeName = "bigint")]
        public Int64 BidPrice { get; set; }
        [Column("Day", TypeName = "date")]
        public DateTime Day { get; set; }
        [Column("Qualified", TypeName = "bit")]
        public bool Qualified { get; set; }
    }
}
