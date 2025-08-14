using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models.Sınıflar;
namespace WebApplication3.Controllers
{
    public class İstatistikController : Controller
    {
        Context c = new Context();
        // GET: İstatistik
        public ActionResult Index()
        {
            var deger1 = c.Carilers.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = c.Products.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = c.Personals.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = c.Categories.Count().ToString();
            ViewBag.d4 = deger4;
            var deger5 = c.Products.Sum(x=>x.Stok).ToString();
            ViewBag.d5 = deger5;
            var deger6 = (from a in c.Products select a.Marka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;
            var deger7 = c.Products.Count(X=>X.Stok <=20).ToString();
            ViewBag.d7 = deger7;
            var deger8 = (from x in c.Products orderby x.SatisFiyat descending select x.ÜrünAd).FirstOrDefault(); ;
            ViewBag.d8 = deger8;
            var deger9 = (from x in c.Products orderby x.SatisFiyat ascending select x.ÜrünAd).FirstOrDefault(); ;
            ViewBag.d9 = deger9;
            var deger10 = c.Products.Count(x => x.ÜrünAd=="Buzdolabı").ToString();
            ViewBag.d10 = deger10;
            var deger11 = c.Products.Count(x => x.ÜrünAd=="Laptop").ToString();
            ViewBag.d11 = deger11;

            var deger12 = c.Products.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y=>y.Key).FirstOrDefault(); ;
            ViewBag.d12 = deger12;

            var deger13 = c.Products.Where(u=>u.ÜrünID==((c.SatisHarekets.GroupBy(x=>x.Urunid).OrderByDescending(z=>z.Count()).Select(y=>y.Key).FirstOrDefault()))).Select(k=>k.ÜrünAd).FirstOrDefault();
            ViewBag.d13 = deger13;

            var deger14 = c.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.d14 = deger14;
            var deger15 = c.SatisHarekets.Count(x => x.Tarih==DateTime.Today).ToString();
            ViewBag.d15 = deger15;

            var deger16 = c.SatisHarekets.Where(x=>x.Tarih==DateTime.Today).Sum(x=> (decimal?)x.ToplamTutar).ToString();
            ViewBag.d16 = deger16;
            return View();
        }
        public ActionResult KolayTablolar()
        {
            //gruplandırma olayı 
            var sorgu = from x in c.Carilers
                        group x by x.CariSehir into g
                        select new SınıfGrup
                        {
                            Şehir = g.Key,
                            Sayi = g.Count()
                        };
            return View(sorgu.ToList());
        }
        public PartialViewResult Partial1()
        {
            var sorgu = from x in c.Personals
                        group x by x.Departmant.DepartmanAd
                        into g
                        select new SınıfGrup2
                        {
                            Departmant = g.Key,
                            Sayi = g.Count()
                        };
            return PartialView(sorgu);
        }
        public PartialViewResult Partial2()
        {
            var sorgu = c.Carilers.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial3()
        {
            var sorgu = c.Products.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial4()
        {
            var sorgu = from x in c.Products
                        group x by x.Marka
                        into g
                        select new SınıfGrup3
                        {
                            Marka = g.Key,
                            Sayi = g.Count()
                        };
            return PartialView(sorgu);
        }

    }
}