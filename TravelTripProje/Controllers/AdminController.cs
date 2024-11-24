using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class AdminController : Controller
    {
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniBlog(Blog blog)
        {
            c.Blogs.Add(blog);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogSil(int id)
        {
            var values = c.Blogs.Find(id);
            c.Blogs.Remove(values);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogGetir(int id)
        {
            var values = c.Blogs.Find(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult BlogGuncelle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BlogGuncelle(Blog blog)
        {
            var values = c.Blogs.Find(blog.ID);
            values.Baslik=blog.Baslik;
            values.Tarih=blog.Tarih;
            values.Aciklama=blog.Aciklama;
            values.BlogImage=blog.BlogImage;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }
        public ActionResult YorumSil(int id)
        {
            var values = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(values);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        public ActionResult YorumGetir(int id)
        {
            var values = c.Yorumlars.Find(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult YorumGuncelle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YorumGuncelle(Yorumlar yorumlar)
        {
            var values = c.Yorumlars.Find(yorumlar.ID);
            values.KullaniciAdi = yorumlar.KullaniciAdi;
            values.Mail = yorumlar.Mail;
            values.Yorum = yorumlar.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
    }
}