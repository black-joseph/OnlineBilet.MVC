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
            return Json(ent.Seferler.Where(s => s.KalkisYeriId == KalkisYerId).Select(s => new
            {
                Id = s.DestinasyonId,
                Destinasyon = s.Destinasyon.DestinasyonYer
            }).ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult TarihGetir(int KalkisYerId , int DestinasyonId)
        {
            return Json(ent.SeferProgramlar.Where(t => t.Sefer.KalkisYeriId == KalkisYerId && t.Sefer.DestinasyonId==DestinasyonId).Select(t => new
            {
                SeferProgramId = t.Id,
                KalkisTarihi = t.KalkisTarihi
            }).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}