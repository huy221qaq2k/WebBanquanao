using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebThoiTrang.Models.EF
{
    [Table("tb_New")]
    public class News : CommonAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage ="Bạn không để trống tiêu đề tin")]
        [StringLength(150)]
        public string Tilte1 { get; set; }
        public string Alias { get; set; }
        public int CategoryID { get; set; }
        public string Description { get; set; }
        [AllowHtml]
        public string Detail { get; set; }
        public string Image{ get; set; }
        public string SeoTiltle { get; set; }
        public string SeoDescrpition { get; set; }
        public string SeoKeywords { get; set; }
        public bool IsActive { get; set; }
        public virtual Category Category { get; set; }
    }
}