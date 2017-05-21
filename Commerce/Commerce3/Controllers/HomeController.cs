using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Commerce3.Models;
using PagedList;
using PagedList.Mvc;



namespace Commerce3.Controllers
{
    public class HomeController : Controller
    {
        Models.Commerce3Entities1 db = new Commerce3Entities1();
        public ActionResult Index(int? page)
        {
            var urunler = db.Urunlers.Where(x => x.Id > 0).ToList().ToPagedList(page ?? 1,2);
            return View(urunler);

        }
        public ActionResult Slider()
        {
            var sliders = db.Mansets.Where(x => x.Id > 0);
            return View(sliders);
        }
        public ActionResult Urungetir()
        {
            var urunlerr = db.Urunlers.Where(x => x.Id > 0);
            return View(urunlerr);
        }
    }

    
}