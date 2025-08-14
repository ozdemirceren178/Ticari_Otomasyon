using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models.Sınıflar
{
    public class Personal
    {
        [Key]
        public int PersonalID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]

        [Display(Name ="Personel Ad")]
        public string PersonalAd { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]

        [Display(Name = "Personel Soyad")]
        public string PersonalSoyad { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(250)]


        [Display(Name = "Personel Görsel")]
        public string PersonalGorsel { get; set; }
        public ICollection<SatisHareket> satisHarekets { get; set; }
       
        [ForeignKey("Departmant")]
        public int DepartmanId { get; set; }
        public virtual Departmant Departmant { get; set; }
    }
}