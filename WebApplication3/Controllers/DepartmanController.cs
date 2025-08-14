using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models.Sınıflar;

namespace WebApplication3.Controllers
{
    [Authorize]
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();

        
        public ActionResult Index()
        {
            var degerelr = c.Departmants.Where(x=>x.Durum==true).ToList();
            return View(degerelr);
        }

        [Authorize(Roles ="A")]
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        
        public ActionResult DepartmanEkle(Departmant d)
        {
            c.Departmants.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult DepartmanSil(int id)
        {
            var dp = c.Departmants.Find(id);
            dp.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var dp = c.Departmants.Find(id);
            return View("DepartmanGetir", dp);           
        }

        public ActionResult DepartmanGüncelle(Departmant d)
        {
            var dp = c.Departmants.Find(d.DepartmenID);
            dp.DepartmanAd = d.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult DepartmanDetay(int id)
        {
            var dgr = c.Personals.Where(x=>x.DepartmanId==id).ToList();
            var dpt = c.Departmants.Where(x=>x.DepartmenID==id).Select(y=>y.DepartmanAd).FirstOrDefault();
            ViewBag.d = dpt;
            return View(dgr);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.PersonalId == id).ToList();
            var p = c.Personals.Where(x => x.PersonalID== id).Select(y => y.PersonalAd+" "+y.PersonalSoyad).FirstOrDefault();
            ViewBag.dpers = p;
            return View(degerler);
        }
    }
}