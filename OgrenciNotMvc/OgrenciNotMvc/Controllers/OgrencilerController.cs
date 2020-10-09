using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class OgrencilerController : Controller
    {
        // GET: Ogrenciler
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var ogrenciler = db.TBLOGRENCILER.ToList();
            return View(ogrenciler);
        }
        [HttpGet]
        public ActionResult OgrenciEkle()
        {
            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString(),
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult OgrenciEkle( TBLOGRENCILER o)
        {
            var klb = db.TBLKULUPLER.Where(m => m.KULUPID == o.TBLKULUPLER.KULUPID).FirstOrDefault();
            o.TBLKULUPLER = klb;
            db.TBLKULUPLER.Add(klb);
            db.TBLOGRENCILER.Add(o);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var ogrenci = db.TBLOGRENCILER.Find(id);
            db.TBLOGRENCILER.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrenciGetir(int id)
        {
            var ogrenci = db.TBLOGRENCILER.Find(id);
            return View("OgrenciGetir", ogrenci);
        }
        public ActionResult Guncelle(TBLOGRENCILER p)
        {
            var ogrenci = db.TBLOGRENCILER.Find(p.OGRENCIID);
            ogrenci.OGRENCIAD = p.OGRENCIAD;
            ogrenci.OGRENCISOYAD = p.OGRENCISOYAD;
            ogrenci.OGRENCIFOTOGRAF = p.OGRENCIFOTOGRAF;
            ogrenci.OGRENCIKULUP = p.OGRENCIKULUP;
            ogrenci.OGRENCICINSIYET = p.OGRENCICINSIYET;
            db.SaveChanges();
            return RedirectToAction("Index", "Ogrenciler");
        }
    }
}