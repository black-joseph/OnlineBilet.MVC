using Bilet.BLL.Repository;
using Bilet.DAL.Context;
using Bilet.Entity.Entity;
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
        [HttpGet]
        public JsonResult OtobusGetir(int KalkisYerId, int DestinasyonId, int SeferId, int SeferSaatId)
        {
            return Json(ent.Otobusler.Where(s => s.SeferSaat.Sefer.Guzergah.KalkisYeriId == KalkisYerId && s.SeferSaat.Sefer.Guzergah.DestinasyonId == DestinasyonId && s.SeferSaat.SeferId == SeferId && s.SeferSaatId==SeferSaatId).Select(s => new
            {
                Id = s.Id,                
                Sofor=s.Sofor
            }).ToList(), JsonRequestBehavior.AllowGet);
        }



        public ActionResult KoltukSec(/*int OtobusId*/)
        {
            //Otobus secilen = (from c in ent.Otobusler
            //                   where c.Id == OtobusId
            //                   select c).FirstOrDefault();

            return View(/*secilen*/);
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