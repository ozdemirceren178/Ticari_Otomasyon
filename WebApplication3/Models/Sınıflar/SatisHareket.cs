using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models.Sınıflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisID { get; set; }
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }

        public int Urunid { get; set; }
        public int CariId { get; set; }
        public int PersonalId { get; set; }
      
        public virtual Cariler cariler { get; set; }
        public virtual  Product product { get; set; }
        public virtual Personal personal { get; set; }
        
    }
}