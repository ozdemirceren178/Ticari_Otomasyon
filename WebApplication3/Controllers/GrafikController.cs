using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication3.Models;
using WebApplication3.Models.Sınıflar;

namespace WebApplication3.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafiş
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var grafikciz = new Chart(600,600);
            grafikciz.AddTitle("Kategori-ürün stok sayısı").AddLegend("Stok").AddSeries("Değerler", xValue: new[] {"Mobilya","Ofis Eşyaları","Sandalyeler"}, yValues: new[] {85,66,98}).Write() ;
            return File(grafikciz.ToWebImage().GetBytes(),"image/jpeg");
        }
        public ActionResult Index3()
        {
            ArrayList xvalue= new ArrayList();// bunalrı yazma amacımız her stoğu göstermek 
            ArrayList yvalue= new ArrayList();
            var sonuclar = c.Products.ToList();
            sonuclar.ToList().ForEach(x=>xvalue.Add(x.ÜrünAd));
            sonuclar.ToList().ForEach(y=>yvalue.Add(y.Stok));
            var grafik = new Chart(width: 800, height: 800).AddTitle("Stoklar")
                .AddSeries(chartType: "Pie", name: "Stok", xValue: xvalue, yValues: yvalue);
            return File(grafik.ToWebImage().GetBytes(),"image/jpeg");              
        }
        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult()
        {
            return Json(UrunListesi(), JsonRequestBehavior.AllowGet);
        }
        public List<sinif1> UrunListesi()
        {
            List<sinif1> snf = new List<sinif1>();
            snf.Add(new sinif1()
            {
               urunad="Bilgisayar",
               stok=120
            });
            snf.Add(new sinif1()
            {
                urunad = "Beyaz Eşya",
                stok = 150
            });
            snf.Add(new sinif1()
            {
                urunad = "Mobilya",
                stok = 70
            });
            snf.Add(new sinif1()
            {
                urunad = "Küüçük Ev Aletleri",
                stok = 180
            });
            snf.Add(new sinif1()
            {
                urunad = "Mobil Cihazlar",
                stok = 90
            });
            return snf;
        }

        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult2()
        {
            return Json(UrunListesi2(), JsonRequestBehavior.AllowGet);
        }
        public List<sinif2> UrunListesi2()
        {
            List<sinif2> snf = new List<sinif2>();
            using (var context= new Context())
            {
                snf = c.Products.Select(x => new sinif2
                {
                    urn=x.ÜrünAd,
                    stk=x.Stok
                }).ToList();
            }
            return snf;
        }
        public ActionResult Index6()
        {
            return View();
        }
        public ActionResult Index7()
        {
            return View();
        }

    }
}