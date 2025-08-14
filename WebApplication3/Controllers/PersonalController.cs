using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Controllers;
using WebApplication3.Models.Sınıflar;

namespace WebApplication3.Controllers
{
    public class PersonalController : Controller
    {
        // GET: Personal
        Context c = new Context();
        public ActionResult Index()
        {
            var dgr = c.Personals.ToList();
            return View(dgr);
        }
        [HttpGet]
        public ActionResult PersonalEkle()
        {
            //dropdown= c# combobox -< aşağıda combovboz yaptık
            List<SelectListItem> dgr = (from x in c.Departmants.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.DepartmanAd,
                                            Value = x.DepartmenID.ToString()
                                        }).ToList();
            ViewBag.dgr1 = dgr; //controllerdan veri taşımak için kullanılır
            return View();
        }
        [HttpPost]
        public ActionResult PersonalEkle(Personal p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/"+dosyaadi+uzanti;

                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonalGorsel = "/Image/" + dosyaadi + uzanti;
            }
            c.Personals.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonalGetir(int id)
        {
            List<SelectListItem> dgr = (from x in c.Departmants.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.DepartmanAd,
                                            Value = x.DepartmenID.ToString()
                                        }).ToList();
            ViewBag.dgr1 = dgr; //controllerdan veri taşımak için kullanılır
           
            var prs = c.Personals.Find(id);
            return View("PersonalGetir", prs);
        }
        public ActionResult PersonalGüncelle(Personal p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;

                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonalGorsel = "/Image/" + dosyaadi + uzanti;
            }
            var pr = c.Personals.Find(p.PersonalID);
            pr.PersonalAd = p.PersonalAd;
            pr.PersonalSoyad = p.PersonalSoyad;
            pr.PersonalGorsel = p.PersonalGorsel;
            pr.DepartmanId = p.DepartmanId;
            return RedirectToAction("Index");
        }

        public ActionResult PersonelList()
         {
            var pl = c.Personals.ToList();
            return View(pl);
        }

    }
}