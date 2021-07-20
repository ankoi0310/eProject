using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineArtGallery.Models
{
    [Table("Transaction")]
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }
        [Column("CustomerId", TypeName = "int")]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        [Column("Date", TypeName = "date")]
        public DateTime Date { get; set; }
        [Column("TotalPrice", TypeName = "bigint")]
        public Int64 TotalPrice { get; set; }
        [Column("TotalFee", TypeName = "bigint")]
        public Int64 TotalFee { get; set; }
        [Column("PaymentId", TypeName = "int")]
        public int PaymentId { get; set; }
        [ForeignKey("PaymentId")]
        public Payment Payment { get; set; }
        [Column("StatusId", TypeName = "int")]
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public Status Status { get; set; }
        [Column("Active", TypeName = "bit")]
        public bool Active { get; set; }
    }
}
