using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models.Sınıflar
{
    public class Mesajlar
    {
        [Key]
        public int Mesajid { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string Gönderen { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string Alıcı { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string Konu { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(2000)]
        public string içerk { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime Tarih { get; set; }
    }
}