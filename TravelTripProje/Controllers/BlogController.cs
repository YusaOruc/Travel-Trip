using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class BlogController : Controller
    {
        BlogYorum by = new BlogYorum();
        Context c = new Context();
        // GET: Blog
        public ActionResult Index()
        {
            //var bloglar = c.Blogs.ToList();
            by.Deger1 = c.Blogs.ToList();
            by.Deger2 = c.Yorumlars.Take(3).ToList();
            by.Deger3 = c.Blogs.Take(3).ToList();
            return View(by);
        }
       
        public ActionResult BlogDetay(int id)
        {
            by.Deger1 = c.Blogs.Where(x => x.ID == id).ToList();
            by.Deger2 = c.Yorumlars.Where(x => x.Blogid == id).ToList();
            by.Deger3 = c.Blogs.Take(3).ToList();
            
            //var blogbul = c.Blogs.Where(x => x.ID == id).ToList();
            return View(by);
        }
        public PartialViewResult YorumPartical()
        {
            by.Deger3 = c.Blogs.Take(3).ToList();
            by.Deger2 = c.Yorumlars.Take(3).ToList();


            return PartialView(by);
        }

       [HttpGet]
       public PartialViewResult YorumYap(int id)
       {
            ViewBag.deger = id;
            return PartialView();
       }

        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {
            c.Yorumlars.Add(y);
            c.SaveChanges();
            return PartialView();
        }
    }
}