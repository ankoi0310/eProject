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
        [Column("AuctionId", TypeName = "int")]
        public int AuctionId { get; set; }
        [ForeignKey("AuctionId")]
        public Auction Auction { get; set; }
        [Key]
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
        [Column("PaymentId", TypeName = "int")]
        public int PaymentId { get; set; }
        [ForeignKey("PaymentId")]
        public Payment Payment { get; set; }
    }
}
