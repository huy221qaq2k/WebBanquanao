using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebThoiTrang.Models.EF
{
    [Table("tb_ProductImage")]
    public class Productimage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductID { get; set; }
        public string Image { get; set; }
        public bool IsDefault { get; set; }

    }
}