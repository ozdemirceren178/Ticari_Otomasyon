using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models.Sınıflar
{
    public class Cariler
    {
        [Key]
        public int CariID { get; set; }


        [Column(TypeName = "VarChar")]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter Yazab" +
            "lirsiniz")]
        public string CariAd { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string CariSoyad { get; set; }


        [Column(TypeName = "VarChar")]
        [StringLength(13)]
        public string CariSehir { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string CariMail { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        public string CariSifre { get; set; }
        public ICollection<SatisHareket> satisHarekets { get; set; }

        public bool Durum { get; set; }
    }
}