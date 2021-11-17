using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;
using PagedList;
using PagedList.Mvc;

namespace TravelTripProje.Controllers
{
    public class YorumController : Controller
    {
        // GET: Yorum
        Context c = new Context();
        [Authorize]
        public ActionResult Index(int sayfa=1)
        {
            //var deger = c.Yorumlars.ToList();
            var deger = c.Yorumlars.ToList().ToPagedList(sayfa, 5);

            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Yorumlar p)
        {
            c.Yorumlars.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var deger = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumGetir(int id)
        {
            var bl = c.Yorumlars.Find(id);
            return View("YorumGetir", bl);
        }
        public ActionResult YorumGuncelle(Yorumlar b)
        {
            var blg = c.Yorumlars.Find(b.ID);
            blg.KullaniciAdi = b.KullaniciAdi;
            blg.Mail = b.Mail;
            blg.Yorum = b.Yorum;
            blg.Blogid = b.Blogid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}