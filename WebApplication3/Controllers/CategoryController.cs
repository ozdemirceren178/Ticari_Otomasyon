using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models.Sınıflar;
using PagedList;
using PagedList.Mvc;

namespace WebApplication3.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context c = new Context();
        public ActionResult Index(int sayfa=1)
            //sayfalama işlemi başladı int sayfa=1 ile 
        {
            var degerler = c.Categories.ToList().ToPagedList(sayfa,4);
            //sayfa,4 değişkeni ile bir sayfada sadece 4 tsne değer görünmesini sağladık 
            return View(degerler);
        }
        //neden 2 defa yaynı metodu yazdık? sayfa ayüklenince de çalışacak
        //başlangıçta boş ekliyck
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        //butona tıklayınca alttaki çalışacak
        [HttpPost]
        public ActionResult KategoriEkle(Category k )
        {
            //k=gönderedeğim parametlereler view tarafında 
            c.Categories.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index"); // kaydettikten sonra Indexe yönlerdir demek
        }

        public ActionResult KategoriSil(int id)
        {
            var kate = c.Categories.Find(id);
            c.Categories.Remove(kate);
            c.SaveChanges();
            return RedirectToAction("Index");              
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = c.Categories.Find(id);
            return View("KategoriGetir", kategori);
        }
        public ActionResult KategoriGüncelle(Category k)
        {
            var kt = c.Categories.Find(k.KategoriID); //değişkne ile sayfadaki ID yi tarayıcıya aldım
            kt.KategoriAd = k.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Deneme()
        {
            Class3 cs = new Class3();
            cs.Kategoriler = new SelectList(c.Categories,"KategoriID", "KategoriAd");
            cs.Urunler = new SelectList(c.Products, "ÜrünID", "ÜrünAd");
            return View(cs);
        }
        public JsonResult  UrunGetir(int p )
        {
            var urunlistesi = (from x in c.Products
                               join y in c.Categories
                               on x.Category.KategoriID equals y.KategoriID
                               where x.Category.KategoriID == p
                               select new
                               {
                                   Text = x.ÜrünAd,
                                   value = x.ÜrünID.ToString()
                               }
                               ).ToList();
            return Json(urunlistesi, JsonRequestBehavior.AllowGet);
        }


    }
}