using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models.Sınıflar;

namespace WebApplication3.Controllers
{
    public class FaturaController : Controller
    {
        Context c = new Context();
        // GET: Fatura
        public ActionResult Index()
        {
            var liste = c.Manifactures.ToList();        
            return View(liste);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();

        }

        [HttpPost]

        public ActionResult FaturaEkle(Manifacture m)
        {
            c.Manifactures.Add(m);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Manifactures.Find(id);
            return View("FaturaGetir", fatura);
        }
        public ActionResult FaturaGüncelle(Manifacture m)
        {
            var md = c.Manifactures.Find(m.FaturaID);
            md.FaturaSeriNo = m.FaturaSeriNo;
            md.FaturaSıraNo = m.FaturaSıraNo;
            md.Tarih = m.Tarih;
            md.VergiDairesi = m.VergiDairesi;
            md.Saat = m.Saat;
            md.TeslimElden = m.TeslimElden;
            md.TeslimAlan = m.TeslimAlan;         
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult FaturaDetay(int id)
        {
            var dgr = c.FaturaKalems.Where(x => x.Faturaid == id).ToList();
            
            return View(dgr);
        }

        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        
        public ActionResult YeniKalem(FaturaKalem p)
        {
            c.FaturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Dinamik()
        {
            Class4 cs = new Class4();
            cs.deger1 = c.Manifactures.ToList();
            cs.deger2 = c.FaturaKalems.ToList();
            return View(cs);
        }
        public ActionResult FaturaKaydet(char FaturaSeriNo, string FaturaSıraNo,DateTime Tarih, string VergiDairesi, string Saat, string TeslimElden, string TeslimAlan, string Tutar, FaturaKalem[] kalemler)
        {
            Manifacture f = new Manifacture();
            f.FaturaSeriNo = FaturaSeriNo;
            f.FaturaSıraNo = FaturaSıraNo;
            f.Tarih = Tarih;
            f.VergiDairesi = VergiDairesi;
            f.TeslimElden = TeslimElden;
            f.TeslimAlan = TeslimAlan;
            f.Toplam = decimal.Parse(Tutar);
            c.Manifactures.Add(f);
            foreach(var x in kalemler)
            {
                FaturaKalem fk = new FaturaKalem();
                fk.Aciklama = x.Aciklama;
                fk.BirimFiyatı = x.BirimFiyatı;
                fk.Faturaid = x.Faturaid;
                fk.Miktar = x.Miktar;
                fk.Tutar = x.Tutar;
                c.FaturaKalems.Add(fk);
            }

            c.SaveChanges();
            return Json("İşlem Başarılı");
        }
    }

   

}