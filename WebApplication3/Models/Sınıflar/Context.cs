using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication3.Models.Sınıflar
{
    public class Context : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Cariler> Carilers { get; set; }
        public DbSet<Departmant> Departmants { get; set; }
        public DbSet<FaturaKalem> FaturaKalems { get; set; }
        public DbSet<Manifacture> Manifactures { get; set; }
        public DbSet<Giderler> Giderlers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Personal> Personals { get; set; }
        public DbSet<SatisHareket> SatisHarekets { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Detay> Detays { get; set; }
        public DbSet<Yapılacaklar> yapılacaklars{get;set;}
        public DbSet<KargoDetay> KargoDetays{get;set;}
        public DbSet<KargoTakip> kargoTakips{get;set;}
        public DbSet<Mesajlar> Mesajlars{get;set;}

         
    }
}