using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineArtGallery.Models
{
    [Table("Status")]
    public class Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }
        [Column("Name", TypeName = "nvarchar")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("Active", TypeName = "bit")]
        public bool Active { get; set; }
    }
}
