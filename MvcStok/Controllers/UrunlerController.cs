using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler
        Db_MvcStokTakibiEntities db = new Db_MvcStokTakibiEntities();
        public ActionResult Index()
        {
            var degerler = db.Tbl_Urunler.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniUrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.Tbl_Kategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Kategoriad,
                                                 Value = i.Kategoriid.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrunEkle(Tbl_Urunler p1)
        {
            var ktg = db.Tbl_Kategori.Where
                (m => m.Kategoriid == p1.Tbl_Kategori.Kategoriid)
                .FirstOrDefault();
            p1.Tbl_Kategori = ktg;
            db.Tbl_Urunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var urunler = db.Tbl_Urunler.Find(id);
            db.Tbl_Urunler.Remove(urunler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.Tbl_Urunler.Find(id);
            List<SelectListItem> degerler = (from i in db.Tbl_Kategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Kategoriad,
                                                 Value = i.Kategoriid.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("UrunGetir", urun);
        }
        public ActionResult UrunGuncelle(Tbl_Urunler p1)
        {
            var urun = db.Tbl_Urunler.Find(p1.Urunid);
            urun.Urunad = p1.Urunad;
            urun.Stok = p1.Stok;
            urun.Urunkategori = p1.Urunkategori;
            urun.Fiyat = p1.Fiyat;
            urun.Marka = p1.Marka;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}