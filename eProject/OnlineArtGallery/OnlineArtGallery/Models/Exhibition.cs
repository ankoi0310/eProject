using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineArtGallery.Models
{
    [Table("Exhibition")]
    public class Exhibition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }
        [Column("Name", TypeName = "nvarchar")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("BeginDay", TypeName = "date")]
        public DateTime BeginDay { get; set; }
        [Column("EndDay", TypeName = "date")]
        public DateTime EndDay { get; set; }
        [Column("Locate", TypeName = "nvarchar")]
        public string Locate { get; set; }
        [Column("Description", TypeName = "nvarchar")]
        public string Description { get; set; }
        [Column("Image", TypeName = "nvarchar")]
        public string Image { get; set; }
        [Column("Active", TypeName = "bit")]
        public bool Active { get; set; }

        [NotMapped]
        public FormFile FileImage { get; set; }
    }
}
