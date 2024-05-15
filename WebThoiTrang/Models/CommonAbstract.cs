using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebThoiTrang.Models
{
    public abstract class CommonAbstract
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifierdDate { get; set; }
        public string ModifierBy { get; set; }
    }
}