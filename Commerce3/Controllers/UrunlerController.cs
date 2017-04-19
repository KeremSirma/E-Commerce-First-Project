using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Commerce3.Models;

namespace Commerce3.Controllers
{
    public class UrunlerController : Controller
    {
        Commerce3.Models.Commerce3Entities1 db = new Models.Commerce3Entities1();
        // GET: Urunler
        public ActionResult Index()
        {
            return View();
        }
        int id = 1;
        public ActionResult Detay(int id)
        {
            var urunlerrrr = db.Urunlers.SingleOrDefault(X => X.Id == id);
            return View(urunlerrrr);
        }
        public ActionResult SatinAl(string id)
        {
            return View(db.Urunlers.FirstOrDefault(x => x.Baslik == id));
        }
        [HttpPost]
        public ActionResult SatinAl(string Urun,string Mail,String İsim,string Telefon,string Mesaj)
        {
            MessageBox ms = new MessageBox();
            ms.AdSoyad = İsim;
            ms.Mail = Mail;
            ms.Urun = Urun;
            ms.Telefon = Telefon;
            ms.Mesaj = Mesaj;
            db.MessageBoxes.Add(ms);
            db.SaveChanges();
            return Redirect("/"); 
        }
    }
}