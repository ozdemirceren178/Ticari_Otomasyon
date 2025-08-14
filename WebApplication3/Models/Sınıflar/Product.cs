using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models.Sınıflar
{
    public class Product
    {
        //ürünümün bir kategorisi olır
        [Key]
        public int ÜrünID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string ÜrünAd { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string Marka { get; set; }
        public short Stok { get; set; } // SHORT NEDİR
        public decimal AlisFiyat { get; set; }
        public decimal SatisFiyat { get; set; }
        public bool Durum { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(250)]
        public string UrünGörsel { get; set; }
        public int KategoriId { get; set; }
        public virtual Category Category { get; set; }

        public  ICollection<SatisHareket> satisHarekets{ get; set; }


    }
}