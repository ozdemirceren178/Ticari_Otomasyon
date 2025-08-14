using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models.Sınıflar
{
    public class Departmant
    {
        [Key]
        public int DepartmenID { get; set; }


        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string DepartmanAd { get; set; }
        public bool Durum { get; set; }
        public ICollection<Personal> Personals { get; set; }
    }
}