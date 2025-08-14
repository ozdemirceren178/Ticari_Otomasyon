using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models.Sınıflar
{
    public class Detay
    {
        [Key]
        public int DetayID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string ürünad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string ürünbilgi { get; set; }       

    }
}