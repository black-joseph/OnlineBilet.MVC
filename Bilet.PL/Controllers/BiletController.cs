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
            List<Sefer> SList = ent.Seferler.ToList();
            ViewBag.kYerList = new SelectList(SList, "KalkisYeriId", "KalkisYer");
            return View();
        }
        //public JsonResult DestinasyonlarByKalkisYerleri()
        //{
        //    var Countries = new List<string>();
        //    Countries.Add("Australia");
        //    Countries.Add("India");
        //    Countries.Add("Russia");
        //    return Json(Countries, JsonRequestBehavior.AllowGet);

        //}
        //[HttpPost]
        //public JsonResult DestinasyonlarByKalkisYerleri(string country)
        //{
        //    var States = new List<string>();
        //    if (!string.IsNullOrWhiteSpace(country))
        //    {
        //        if (country.Equals("Australia"))
        //        {
        //            States.Add("Sydney");
        //            States.Add("Perth");
        //        }
        //        if (country.Equals("India"))
        //        {
        //            States.Add("Delhi");
        //            States.Add("Mumbai");
        //        }
        //        if (country.Equals("Russia"))
        //        {
        //            States.Add("Minsk");
        //            States.Add("Moscow");
        //        }
        //    }
        //    return Json(States, JsonRequestBehavior.AllowGet);
        //}

    }
}