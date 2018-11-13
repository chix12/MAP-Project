using MapData;
using MapDomain.Entities;
using MapService;
using MapWeb.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MapWeb.Controllers
{
    public class StatController : Controller
    {
        private ApplicationDbContext u = new ApplicationDbContext();

        MapContext db = new MapContext();
        RessourceService sr = new RessourceService();
        // GET: Stat
        public ActionResult IndexStat()
        {
            return View();
        }

        public ActionResult GetData()
        {
            //var Ress = db.GetMany().Where(x => x.AccountType == "Ressource" );


            var Ressources = sr.GetMany().ToList();
            var emp = Ressources.Where(x => x.typec.ToString() == "Employee").Count();
            var pig = Ressources.Where(x => x.typec.ToString() == "Freelancer").Count();
            Ratio obj = new Ratio();
            obj.pig = pig;
            obj.emp = emp;



            return Json(obj, JsonRequestBehavior.AllowGet);

        }
         public class Ratio
        {
        public int pig { get; set; }
        public int emp { get; set; }
        }
    }
}