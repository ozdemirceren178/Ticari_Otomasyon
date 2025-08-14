using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication3.Models.Sınıflar;

namespace WebApplication3.Controllers
{
    public class CariPanelController : Controller
    {
        Context c = new Context();
        // GET: CariPanel
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var deger = c.Mesajlars.Where(x=>x.Alıcı==mail).ToList();
            ViewBag.m = mail;
            var mailid = c.Carilers.Where(x=>x.CariMail==mail).Select(y=>y.CariID).FirstOrDefault();
            ViewBag.mid = mailid;
            var toplamsatis = c.SatisHarekets.Where(x => x.CariId == mailid).Count();
            ViewBag.toplamsatis = toplamsatis;
            var toplamtutar = c.SatisHarekets.Where(x=>x.CariId==mailid).Sum(y=>y.ToplamTutar);
            ViewBag.toplamtutar = toplamtutar;
            var toplamürün = c.SatisHarekets.Where(x=>x.CariId==mailid).Sum(y=>y.Adet);
            ViewBag.toplamürün = toplamürün;
            var adsoyad = c.Carilers.Where(x => x.CariMail == mail).Select(y=>y.CariAd+ " " +y.CariSoyad).FirstOrDefault();
            ViewBag.ads = adsoyad;
            return View(deger);
        }
        [Authorize]
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariID).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x=>x.CariId==id).ToList();
            return View(degerler);
        }
        [Authorize]
        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Mesajlars.Where(x=>x.Alıcı==mail).OrderByDescending(z=>z.Mesajid).ToList();
            var gelensayisi = c.Mesajlars.Count(x => x.Alıcı == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(x => x.Gönderen == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(mesajlar);
        }
        [Authorize]
        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Mesajlars.Where(x => x.Gönderen == mail).OrderByDescending(z=>z.Mesajid).ToList();
            var gelensayisi = c.Mesajlars.Count(x => x.Alıcı == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(x => x.Gönderen == mail).ToString();
            ViewBag.d2 = gidensayisi;

            return View(mesajlar);
        }
        [Authorize]
        public ActionResult MesajDetay(int id)
        {
            var degerler = c.Mesajlars.Where(x => x.Mesajid == id).ToList();
        
            var mail = (string)Session["CariMail"];
            var gelensayisi = c.Mesajlars.Count(x => x.Alıcı == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(x => x.Gönderen == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(degerler);
        }
        [Authorize]
        [HttpGet]
          public ActionResult YeniMesaj()
          {
            var mail = (string)Session["CariMail"];
            var gelensayisi = c.Mesajlars.Count(x => x.Alıcı == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(x => x.Gönderen == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View();
          }
        [Authorize]
        [HttpPost]
          public ActionResult YeniMesaj(Mesajlar m)
          {
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            var mail = (string)Session["CariMail"];
            m.Gönderen = mail;
            c.Mesajlars.Add(m);
            c.SaveChanges();
            
            return View();
          }
        [Authorize]
        public ActionResult KargoTakip(string p )
        {
            var k = from x in c.KargoDetays select x;

                k = k.Where(y => y.TakipKodu.Contains(p));
            
            return View(k.ToList());
          
        }
        [Authorize]
        public ActionResult CariKargoTakip(string id)
        {
            var degerler = c.kargoTakips.Where(x=>x.TakipKodu==id).ToList();
            return View(degerler);
        }
        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
        public PartialViewResult Partial1()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariID).FirstOrDefault();
            var caribul = c.Carilers.Find(id);
            return PartialView("Partial1",caribul);
        }
        public PartialViewResult Partial2()
        {
            var veriler = c.Mesajlars.Where(x => x.Gönderen == "admin").ToList();
            return PartialView(veriler);
        }
        public ActionResult CariBilgiGüncelle(Cariler cr)
        {
            var cari = c.Carilers.Find(cr.CariID);
            cari.CariAd = cr.CariAd;
            cari.CariSoyad = cr.CariSoyad;
            cari.CariSifre = cr.CariSifre;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
            
        
    }
}