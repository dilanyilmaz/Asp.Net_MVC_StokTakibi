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
        public ActionResult Index()
        {
            var degerler = db.Tbl_Musteri.ToList(); 
            return View(degerler);
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
    }
}