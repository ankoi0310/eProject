using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineArtGallery.Models
{
    [Table("Notification")]
    public class Notification
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public bool IsRead { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; }
        private int? transactionId;
        public int? TransactionId { get => transactionId == 0 ? null : transactionId; set => transactionId = value; }
        public DBContext context = new DBContext();
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string IsReadSt => this.IsRead ? "YES" : "NO";
    }
}
