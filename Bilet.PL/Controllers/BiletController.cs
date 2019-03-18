using Bilet.BLL.Repository;
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
        
        // GET: Bilet
        public ActionResult Index()
        {
            
            return View();
        }
    }
}