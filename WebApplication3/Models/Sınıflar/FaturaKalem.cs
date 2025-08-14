using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models.Sınıflar
{
    public class FaturaKalem
    {

        [Key]
        public int FaturaKalemID { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(100)]
        public string Aciklama { get; set; }
        public int Miktar { get; set; }
        public decimal BirimFiyatı { get; set; }
        public decimal Tutar { get; set; }
        public int Faturaid { get; set; }         
        public virtual Manifacture Manifacture { get; set; }
    }
}