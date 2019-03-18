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
    public class BaseController : Controller
    {
        BiletContext ent = new BiletContext();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Repository<Sefer> repoS = new Repository<Sefer>(ent);
            ViewBag.Seferler = repoS.GetAll();

            //Repository<Tag> repoT = new Repository<Tag>(ent);
            //ViewBag.Etiketler = repoT.GetAll(null, t => t.OrderByDescending(x => x.Articles.Count)).Take(5);

            base.OnActionExecuting(filterContext);
        }

    }
}