using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebThoiTrang.Models.EF
{
    [Table("tb_Post")]
    public class Posts : CommonAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Tilte { get; set; }
        [StringLength(150)]
        public string Alias { get; set; }
        public int CategoryID { get; set; }
        public string Description { get; set; }

        [AllowHtml]
        public string Detail { get; set; }
        [StringLength(250)]
        public string Image { get; set; }


        [StringLength(250)]
        public string SeoTiltle { get; set; }
        [StringLength(500)]
        public string SeoDescrpition { get; set; }
        [StringLength(250)]
        public string SeoKeywords { get; set; }
        public bool IsActive { get; set; }
        public virtual Category Category { get; set; }
    }
}