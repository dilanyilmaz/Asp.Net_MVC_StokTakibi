using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Db_MvcStokTakibiEntities db = new Db_MvcStokTakibiEntities();
        public ActionResult Index()
        {
            var degerler = db.Tbl_Kategori.ToList();
            return View(degerler);
        }
        [HttpGet] 
        public ActionResult YeniKategori()
        {
            return View();   
        }
        [HttpPost]
        public ActionResult YeniKategori(Tbl_Kategori p1)
        {
            db.Tbl_Kategori.Add(p1);
            db.SaveChanges();   
            return View();  
        }
        public ActionResult Sil(int id)
        {
            var kategori = db.Tbl_Kategori.Find(id);
            db.Tbl_Kategori.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }
    }
}