using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciNotMvc.Controllers
{
    public class HesapTestController : Controller
    {
        // GET: HesapTest
        public ActionResult Index(float sayi1=0,float sayi2=0)
        {
            float toplama = sayi1 + sayi2;
            float cıkarma = sayi1 - sayi2;
            float carpma = sayi1 * sayi2;
            float bolme = sayi1 / sayi2;
            ViewBag.tpl = toplama;
            ViewBag.ckrm = cıkarma;
            ViewBag.crpm = carpma;
            ViewBag.blm = bolme;
            return View();
        }
    }
}