using MapData;
using MapDomain.Entities;
using MapService;
using MapWeb.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
        ServiceMandat sm = new ServiceMandat();
        // GET: Stat
        public ActionResult IndexStat()
        {
            return View();
        }
        // GET: Stat
        public ActionResult IndexM()
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


        public class MR
        {
            public int ressmandat { get; set; }
            public int ressinter { get; set; }


        }
      
        public ActionResult GenerateGraph()
        {
       
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\mssqllocaldb; Initial Catalog=Map;Integrated Security=true");
            con.Open();
            SqlCommand da = new SqlCommand(@"SELECT  COUNT(Distinct AspNetUsers.Id) AS m
                                                FROM       AspNetUsers, Mandats
                                                where  Mandats.Ressource_Id = AspNetUsers.Id",con);

           
            MR obj2 = new MR();


        
            int ressmandat = (Int32)da.ExecuteScalar();

            SqlCommand di = new SqlCommand(@"SELECT COUNT (AspNetUsers.Id) AS i 
                                                FROM AspNetUsers 
                                                WHERE AspNetUsers.Discriminator = 'Ressource'", con);
            int ress = (Int32)di.ExecuteScalar();
            int ressinter = ress - ressmandat;

            obj2.ressmandat = ressmandat;
            obj2.ressinter = ressinter;


            return Json(obj2, JsonRequestBehavior.AllowGet);
            }
        }
    }
