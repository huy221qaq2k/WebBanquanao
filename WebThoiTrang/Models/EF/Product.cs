﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebThoiTrang.Models.EF
{
    [Table("tb_Product")]
    public class Product : CommonAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Tilte { get; set; }
        [StringLength(250)]
        public string Alias { get; set; }

        [StringLength(50)]
        public string ProductCode { get; set; }
        public int ProductCategoryID { get; set; }
        public string Description { get; set; }

        [AllowHtml]
        public string Detail { get; set; }

        [StringLength(250)]
        public string Image { get; set; }
        public decimal Price { get; set; }
        public decimal PriceSale { get; set; }
        public bool IsHome { get; set; }
        public bool IsSale { get; set; }
        public bool IsFeature {  get; set; }
        public bool IsHot { get; set; }
        public bool IsActive { get; set; }
        public int Quantity { get; set; }

        [StringLength(250)]
        public string SeoTiltle { get; set; }
        [StringLength(500)]
        public string SeoDescrpition { get; set; }
        [StringLength(250)]
        public string SeoKeywords { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
}