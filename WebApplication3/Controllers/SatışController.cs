using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models.Sınıflar;
namespace WebApplication3.Controllers
{
    public class SatışController : Controller
    {
        // GET: Satış
        Context c = new Context();
        public ActionResult Index(string p, int sayfa = 1)
        {
            var satis = c.SatisHarekets
                .Include(x => x.product)
                .Include(x => x.cariler)
                .Include(x => x.personal);

            if (!string.IsNullOrEmpty(p))
            {
                satis = satis.Where(y => y.personal.PersonalAd.Contains(p) ||
            y.cariler.CariAd.Contains(p) ||
            y.product.ÜrünAd.Contains(p));
            }
            var degerler = c.SatisHarekets.ToList().ToPagedList(sayfa, 4);

            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            //combobox yaptır
            List<SelectListItem> deger1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ÜrünAd,
                                               Value= x.ÜrünID.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd+" "+ x.CariSoyad,
                                               Value = x.CariID.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in c.Personals.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonalAd+" "+x.PersonalSoyad,
                                               Value = x.PersonalID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;//controlelrden veri taşı
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ÜrünAd,
                                               Value = x.ÜrünID.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariID.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in c.Personals.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonalAd + " " + x.PersonalSoyad,
                                               Value = x.PersonalID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;//controlelrden veri taşı
            var deger = c.SatisHarekets.Find(id);
            return View("SatisGetir", deger);
        }

        public ActionResult ÜrünGüncelle(SatisHareket s)
        {
            var cs = c.SatisHarekets.Find(s.SatisID);
            cs.CariId = s.CariId;
            cs.Adet = s.Adet;
            cs.Tarih = s.Tarih;
            cs.Urunid = s.Urunid;
            cs.PersonalId = s.PersonalId;
            cs.ToplamTutar = s.ToplamTutar;
            cs.Fiyat = s.Fiyat;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Detay(int id)
        {
            var dty = c.SatisHarekets.Where(x => x.SatisID == id).ToList();
            return View(dty);


        }
    }
}