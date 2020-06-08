using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcCoreGiris.Models;
using MvcCoreGiris.Services;

namespace MvcCoreGiris.Controllers
{
    public class KisilerController : Controller
    {
        private readonly OkulContext db; 
        //private static LuckyNumberService lns = new LuckyNumberService();
        public KisilerController(OkulContext okulContext)
        {
            db = okulContext;
        }

        //GET:Kisiler
        public IActionResult Index()
        {
            //ViewBag.lns = lns;
            //TempData["ad"] = "falanca";
            return View(db.Kisiler.ToList());
        }

        public IActionResult Yeni()
        {
            //var kullan = TempData["ad"];
            var lns = (LuckyNumberService)HttpContext.RequestServices.GetService(typeof(LuckyNumberService));
            ViewBag.SansliSayi = lns;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Yeni(Kisi kisi)
        {
            if (ModelState.IsValid)
            {
                db.Add(kisi); // db.Kisiler.Add(kisi); Tablo türünü kendi anlar
                db.SaveChanges();
                TempData["mesaj"] = $"\"{kisi.KisiAd}\" adlı kişi başarıyla eklenmiştir.";
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public IActionResult Duzenle(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }

            var kisi = db.Kisiler.Find(id);
            if (kisi==null)
            {
                return NotFound();
            }

            return View(kisi);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Duzenle(Kisi kisi)
        {
            //ModelState.AddModelError("","bir hata");
            if (ModelState.IsValid)
            {
                //db.Entry(kisi).State =EntityState.Modified;
                db.Update(kisi);
                db.SaveChanges();
                TempData["mesaj"] = $"\"{kisi.KisiAd}\" adlı kişinin bilgileri başarıyla güncellenmiştir.";
                return RedirectToAction(nameof(Index));
            }


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Sil(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var kisi = db.Kisiler.Find(id);
            if (kisi == null)
            {
                return NotFound();
            }

            db.Remove(kisi);
            db.SaveChanges();
            TempData["mesaj"] = $"\"{kisi.KisiAd}\" adlı kişi başarıyla silinmiştir.";
            return RedirectToAction(nameof(Index));
        }
    }
}