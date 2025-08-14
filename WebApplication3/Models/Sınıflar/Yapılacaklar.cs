using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models.Sınıflar
{
    public class Yapılacaklar
    {
        [Key]
        public int YapılacakID { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string Baslik { get; set; }


        [Column(TypeName = "bit")]
        public bool Durum { get; set; }
       
    }
}