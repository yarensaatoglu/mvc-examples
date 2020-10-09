using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;
using OgrenciNotMvc.Models;

namespace OgrenciNotMvc.Controllers
{
    public class NotlarController : Controller
    {
        // GET: Notlar
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var notlar = db.TBLNOTLAR.ToList();
            return View(notlar);
        }
        [HttpGet]
        public ActionResult NotEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NotEkle(TBLNOTLAR n)
        {
            db.TBLNOTLAR.Add(n);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult NotGetir(int id)
        {
            var not = db.TBLNOTLAR.Find(id);
            return View("NotGetir", not);
        }
        [HttpPost]
        public ActionResult NotGetir(Class1 model, TBLNOTLAR p, int sınav1=0, int sınav2=0, int sınav3=0, int proje=0)
        {
            if(model.islem == "Hesapla")
            {
                sınav1 = (int)p.SINAV1;
                sınav2 = (int)p.SINAV2;
                sınav3 = (int)p.SINAV3;
                proje = (int)p.PROJE;
                int ortalama = (sınav1 + sınav2 + sınav3 + proje) / 4;
                ViewBag.ort = ortalama;
            }
            if(model.islem == "Guncelle")
            {
                var sınav = db.TBLNOTLAR.Find(p.NOTID);
                sınav.SINAV1 =p.SINAV1;
                sınav.SINAV2 = p.SINAV2;
                sınav.SINAV3 = p.SINAV3;
                sınav.PROJE = p.PROJE;
                sınav.ORTALAMA = p.ORTALAMA;
                db.SaveChanges();
                return RedirectToAction("Index", "Notlar");
            }
            return View();

        }
    }
}