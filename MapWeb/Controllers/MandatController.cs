using MapWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MapService;
using MapDomain.Entities;

namespace MapWeb.Controllers
{
    public class MandatController : Controller
    {
        ServiceMandat sm = new ServiceMandat();
       RessourceService sr= new RessourceService();
        // GET: Mandat
        public ActionResult IndexMandat()
        {
            var Mandats = sm.GetMany();
            return View(Mandats);
        }
        public ActionResult CreateMandat()
        {

            MandatModel pm = new MandatModel();
            pm.Ressources = sr.GetMany().Where( r => r.AccountType == "Resource").Select(m => new SelectListItem 
            {
                Text = m.Name,
                Value = m.Id.ToString()
            });
                        return View(pm);

        }
        [HttpPost]
        public ActionResult CreateMandat(MandatModel pm )
        {
            Mandat m = new Mandat
            {
                StartDate = pm.StartDate,
                EndDate = pm.EndDate

            };
            return View(pm);
            sm.Add(m);
            sm.Commit();
            return RedirectToAction("FrontEndLayout");
        }
     
    }
}