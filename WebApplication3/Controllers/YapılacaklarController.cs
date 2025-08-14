using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Controllers;
using WebApplication3.Models.Sınıflar;

namespace WebApplication3.Controllers
{
    public class YapılacaklarController : Controller
    {
        // GET: Yapılacaklar
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Carilers.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = c.Products.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = c.Categories.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = (from x in c.Carilers select x.CariSehir).Distinct().Count().ToString(); ;
           ViewBag.d4 = deger4;

            var yapilacaklar = c.yapılacaklars.ToList();



            return View(yapilacaklar);
        }
    }
}