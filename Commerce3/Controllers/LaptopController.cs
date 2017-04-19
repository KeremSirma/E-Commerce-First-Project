using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Commerce3.Models;

namespace Commerce3.Controllers
{
    public class LaptopController : Controller
    {
        Commerce3Entities1 db = new Commerce3Entities1();
        public ActionResult Index()
        {
            return View(db.Urunlers.Where(x=>x.Kategori==1));
        }
    }
}