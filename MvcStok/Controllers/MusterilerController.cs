using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class MusterilerController : Controller
    {
        // GET: Musteriler
        Db_MvcStokTakibiEntities db = new Db_MvcStokTakibiEntities();   
        public ActionResult Index(string p)
        {
            var degerler = from d in db.Tbl_Musteri select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.Musteriad.Contains(p));
            }
            return View(degerler.ToList());
        }
        [HttpGet]
        public ActionResult MusteriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MusteriEkle(Tbl_Musteri p4)
        {
            db.Tbl_Musteri.Add(p4); 
            db.SaveChanges();   
            return View();  
        }
        public ActionResult Sil(int id)
        {
            var musteri=db.Tbl_Musteri.Find(id);    
            db.Tbl_Musteri.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");  
        }
        public ActionResult MusteriGetir(int id)
        {
            var ktgr = db.Tbl_Musteri.Find(id);
            return View("MusteriGetir", ktgr);
        }
        public ActionResult MusteriGuncelle(Tbl_Musteri p1)
        {
            var mus = db.Tbl_Musteri.Find(p1.Musteriid);
            mus.Musteriad = p1.Musteriad;
            mus.Musterisyad = p1.Musterisyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}