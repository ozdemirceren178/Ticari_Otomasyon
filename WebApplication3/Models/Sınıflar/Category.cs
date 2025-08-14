using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models.Sınıflar
{
    public class Category
    {
        [Key]
        public int KategoriID { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string KategoriAd { get; set; }


        public ICollection<Product> Products { get; set; } // ürünleri tutması içi m// her bir kategorimde birden fazla ürün yer alabilir

    }
}