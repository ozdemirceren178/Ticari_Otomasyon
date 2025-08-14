using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models.Sınıflar;

namespace WebApplication3.Controllers
{
    public class UrunController : Controller
    {
        // GET: üRÜN
        Context c = new Context();
        public ActionResult Index(string p, int sayfa=1)
        {
            var urunler = from x in c.Products select x;
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y=>y.ÜrünAd.Contains(p));
            }          
            var degerler = urunler.OrderBy(x => x.ÜrünID).ToPagedList(sayfa, 6);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            //dropdown= c# combobox -< aşağıda combovboz yaptık
            List<SelectListItem> dgr = (from x in c.Categories.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.KategoriAd,
                                            Value = x.KategoriID.ToString()
                                        }).ToList();
            ViewBag.dgr1 = dgr; //controllerdan veri taşımak için kullanılır
                return View();

        }

        [HttpPost]
        public ActionResult YeniUrun(Product p)
        {
            c.Products.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var deger = c.Products.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {

            List<SelectListItem> dgr = (from x in c.Categories.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.KategoriAd,
                                            Value = x.KategoriID.ToString()
                                        }).ToList();
            ViewBag.dgr1 = dgr;

            var urundgr = c.Products.Find(id);

            return View( "UrunGetir", urundgr);
        }

        public ActionResult UrunGüncelle(Product p)
        {
            var ut = c.Products.Find(p.ÜrünID);
            ut.AlisFiyat = p.AlisFiyat;
            ut.SatisFiyat = p.SatisFiyat;
            ut.KategoriId = p.KategoriId;
            ut.Marka = p.Marka;
            ut.Stok = p.Stok;
            ut.Durum = p.Durum;
            ut.ÜrünAd = p.ÜrünAd;
            ut.UrünGörsel = p.UrünGörsel
            ;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunListesi()
        {
            var dgr = c.Products.ToList();
            return View(dgr);
        }
        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> deger3 = (from x in c.Personals.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonalAd + " " + x.PersonalSoyad,
                                               Value = x.PersonalID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger3;
            var deger1 = c.Products.Find(id);
           
            ViewBag.dgr2 = deger1.ÜrünID;
            ViewBag.dgr3 = deger1.SatisFiyat;
            
            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SatisHareket p)
        {
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index","Satış");
            
        }

    }
}