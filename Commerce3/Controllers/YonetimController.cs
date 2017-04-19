using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Commerce3.Models;
using System.Data.Entity;
using System.Drawing;
using System.IO;


namespace Commerce3.Controllers
{
    public class YonetimController : Controller
    {
        // GET: Yonetim
        Commerce3Entities1 db = new Commerce3Entities1();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Mesaj()
        {
            return View(db.MessageBoxes.ToList());
        }

        [HttpPost]
        public ActionResult Index(string id,string pass)
        {
            var deger = db.Logins.Where(x => x.Kullanici == id && x.Sifre == pass).FirstOrDefault();
            if(deger!=null)
            {
                Response.Redirect("/Yonetim");
            }
            else
            {
                Response.Redirect("/Yonetim/Yonetim/");
            }
            return View();
        }
        public ActionResult Yonetim()
        {
            return View(db.Urunlers.ToList());
        }
        string ResimKaydet(HttpPostedFileBase file)
        { 
            Image orj = Image.FromStream(file.InputStream);
            string yol = Path.GetFileNameWithoutExtension(file.FileName) + Guid.NewGuid() + Path.GetExtension(file.FileName);
            orj.Save(Server.MapPath("/Content/images/" + yol));
            return yol;
        }
        [HttpPost]
        public ActionResult Create(Urunler urun,HttpPostedFileBase resim)
        {
            string yolunyolu = ResimKaydet(resim);
            urun.ResimYolu = "/Content/images/" + yolunyolu;
            db.Urunlers.Add(urun);
                db.SaveChanges();
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var gelen = db.Urunlers.Where(x => x.Id == id).FirstOrDefault();
            return View(gelen);
        }
        [HttpPost]
        public ActionResult Edit(Urunler urun)
        {
            db.Entry(urun).State = EntityState.Modified;
            db.SaveChanges();
            return View();
        }
    }
}