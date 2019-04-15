using Bilet.BLL.Repository;
using Bilet.DAL.Context;
using Bilet.Entity.Entity;
using Bilet.PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bilet.PL.Controllers
{
    public class BiletController : BaseController
    {
        BiletContext ent = new BiletContext();
        // GET: Bilet
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpGet]
        public JsonResult DestinasyonGetir(int KalkisYerId)
        {
            return Json(ent.Guzergahlar.Where(s => s.KalkisYeriId == KalkisYerId).Select(s => new
            {
                Id = s.DestinasyonId,
                Destinasyon = s.Destinasyon.DestinasyonYer
            }).ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult TarihGetir(int KalkisYerId , int DestinasyonId)
        {
            return Json(ent.Seferler.Where(t => t.Guzergah.KalkisYeriId == KalkisYerId && t.Guzergah.DestinasyonId==DestinasyonId).Select(t => new
            {
                Id = t.Id,
                KalkisTarihi = t.KalkisTarihi
            }).ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult SaatGetir(int KalkisYerId, int DestinasyonId , int SeferId)
        {
            return Json(ent.SeferSaatler.Where(s => s.Sefer.Guzergah.KalkisYeriId == KalkisYerId && s.Sefer.Guzergah.DestinasyonId == DestinasyonId && s.SeferId==SeferId).Select(s => new
            {
                Id = s.Id,
                KalkisSaati = s.KalkisSaati
            }).ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult KoltukSec(int SeferSaatId)
        {
            SeferSaat secilen = (from c in ent.SeferSaatler
                              where c.Id == SeferSaatId
                              select c).FirstOrDefault();

            return View(secilen);
        }
        [HttpGet]
        public ActionResult SecilenKoltuk(List<int> KoltukNolar)
        {
            //BiletSatisDetay bd = ent.BiletSatisDetaylar.Where(b => b.KoltukNo == KoltukNo).FirstOrDefault();
            foreach (var KoltukNo in KoltukNolar)
            {
                cSepet secilen = new cSepet();
                secilen.KoltukNo = KoltukNo;

                List<cSepet> sepet = cSepet.SepetAl();
                secilen.SepeteEkle(sepet, secilen);
            }
           
            return RedirectToAction("Odemeler");
            
        }
        public ActionResult Odemeler()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult KoltukSec(List<int> KoltukNumaralar)
        //{
        //    Product degisen = (from c in ent.Products
        //                       where c.Id == Degismis.Id
        //                       select c).FirstOrDefault();
        //    degisen.ProductName = Degismis.ProductName;
        //    degisen.Price = Degismis.Price;
        //    degisen.UnitsInStock = Degismis.UnitsInStock;
        //    degisen.CategoryId = Degismis.CategoryId;

        //    ent.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}