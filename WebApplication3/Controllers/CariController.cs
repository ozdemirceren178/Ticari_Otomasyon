using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models.Sınıflar;

namespace WebApplication3.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var degerelr = c.Carilers.Where(x=>x.Durum==true).ToList();
            return View(degerelr);
        }
        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniCari(Cariler ct)
        {
            ct.Durum = true;
            c.Carilers.Add(ct);
            c.SaveChanges();
            return RedirectToAction("Index");     
        }
        public ActionResult CariSil(int id)
        {
            var cr = c.Carilers.Find(id);
            cr.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var cr = c.Carilers.Find(id);
            return View("CariGetir", cr);

        }

        public ActionResult CariGüncelle(Cariler cs)
        {
            var cari = c.Carilers.Find(cs.CariID);
            cari.CariAd = cs.CariAd;
            cari.CariSoyad = cs.CariSoyad;
            cari.CariMail = cs.CariMail;
            cari.CariSehir = cs.CariSehir;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult MusteriSatıs(int id)
        {
            var degerelr = c.SatisHarekets.Where(x => x.CariId == id).ToList();
            var cr = c.Carilers.Where(x=>x.CariID==id).Select(y=>y.CariAd+""+ y.CariSoyad).FirstOrDefault();
            ViewBag.cari = cr;
            return View(degerelr);
            //FİRSTORDEFAULT YAZMAZSAK DÖNGÜYE GİRER 
        }
    }
}