using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Db_MvcStokTakibiEntities db = new Db_MvcStokTakibiEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.Tbl_Kategori.ToList();
            var degerler = db.Tbl_Kategori.ToList().ToPagedList(sayfa,2);
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
        public ActionResult KategoriGetir(int id)
        {
            var ktgr= db.Tbl_Kategori.Find(id);
            return View("KategoriGetir",ktgr);  
        }
        public ActionResult Guncelle(Tbl_Kategori p1)
        {
            var ktgr = db.Tbl_Kategori.Find(p1.Kategoriid);
            ktgr.Kategoriad = p1.Kategoriad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }  
}