using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models.Sınıflar;


namespace WebApplication3.Controllers
{
    public class UrünDetayController : Controller
    {
        // GET: UrünDetay
        Context c = new Context();
        public ActionResult Index()
        {
            Class1 cs = new Class1();

            // var degerler = c.Products.Where(x => x.ÜrünID == 1).ToList(); ;
            cs.Deger1 = c.Products.Where(x => x.ÜrünID == 1).ToList();
            cs.Deger2 = c.Detays.Where(y => y.DetayID == 1).ToList();
            return View(cs);
        }
    }
}