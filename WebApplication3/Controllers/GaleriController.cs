using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models.Sınıflar;

namespace WebApplication3.Controllers
{
    public class GaleriController : Controller
    {
        // GET: Galeri

        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Products.ToList();
            return View(degerler);
        }
    }
}