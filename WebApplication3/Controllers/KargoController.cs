using Microsoft.SqlServer.Server;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models.Sınıflar;

namespace WebApplication3.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        Context c = new Context();
        public ActionResult Index(string p )
        {
            var k = from x in c.KargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                k = k.Where(y => y.TakipKodu.Contains(p));
            }
            return View(k.ToList());
        }
        [HttpGet]
        public ActionResult YenikargoEkle()
        {
            Random rnd = new Random();
            string[] karakterler = { "A", "B","C","D" };
            int k1, k2, k3;
            k1 = rnd.Next(0,4);// 0-1-2-3 değerelrinden birini alabilir
            k2 = rnd.Next(0,4);// 0-1-2-3 değerelrinden birini alabilir
            k3 = rnd.Next(0,4);// 0-1-2-3 değerelrinden birini alabilir
            int s1, s2, s3;
            s1 = rnd.Next(100,1000);//toplam 10 ihtiyacımız var 
            s2 = rnd.Next(10,99);
            s3 = rnd.Next(10,99); // bu sayede birbirinden bağımsız değerler elde edşilecek
            string kod = s1.ToString()+ karakterler[k1] +s2+ karakterler[k2] +s3+ karakterler[k3];
            ViewBag.takipkod = kod;
            return View();
        }

        [HttpPost]
        public ActionResult YeniKargoEkle(KargoDetay d)
        {
            c.KargoDetays.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult KargoTakip(string id)
        {
           // p = "929A55C29A";
            var dgr = c.kargoTakips.Where(x => x.TakipKodu == id).ToList();      
            return View(dgr);
        }
        public ActionResult Karekod(int id)
        {
            var takip = c.KargoDetays.Find(id);
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator kodüret = new QRCodeGenerator();
                QRCodeGenerator.QRCode karekod = kodüret.CreateQrCode(takip.TakipKodu, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap resim = karekod.GetGraphic(10))
                {
                    resim.Save(ms, ImageFormat.Png);
                    ViewBag.karekodimage = "data: image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }

            }
            return View("karekod", takip);
        } 

    }
}