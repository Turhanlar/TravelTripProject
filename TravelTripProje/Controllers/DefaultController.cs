using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class DefaultController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var value = c.Blogs.Take(8).ToList();
            return View(value);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Partial1()
        {
            var degerler = c.Blogs.OrderByDescending(x => x.ID).Take(2).ToList();
            return PartialView(degerler);
        }

        public ActionResult Partial2()
        {
            var deger = c.Blogs.Where(x => x.ID == 1).ToList();
            return PartialView(deger);
        }

        public PartialViewResult Partial3()
        {
            var deger = c.Blogs.Take(10).ToList();
            return PartialView(deger);
        }

        public PartialViewResult Partial4()
        {
            var deger = c.Blogs.Take(3).ToList();
            return PartialView(deger);
        }

        public PartialViewResult Partial5()
        {
            var deger = c.Blogs.OrderByDescending(x=>x.ID).Take(3).ToList();
            return PartialView(deger);
        }
    }
}