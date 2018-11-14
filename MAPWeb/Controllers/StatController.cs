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
        // GET: Stat
        public ActionResult IndexThree()
        {
            return View();
        }
        // GET: Stat
        public ActionResult IndexMeetings()
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
        [HttpPost]
        public JsonResult GetElements()
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\mssqllocaldb; Initial Catalog=Map;Integrated Security=true");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(@"Select P.Name as Name ,Count(Ressource_Id)  as nbr from RessourceProjects RP,Projects P where  P.IdProject = RP.Project_IdProject  group by Name ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<GraphModal> lst = new List<GraphModal>();
            foreach (DataRow row in dt.Rows)
            {
                lst.Add(new GraphModal() { Name2 = row["Name"].ToString(), nbr2 = int.Parse(row["nbr"].ToString()) });
            }
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
        public class GraphModal
        {
            public string Name2 { get; set; }
            public int nbr2 { get; set; }


        }
        [HttpPost]
        public JsonResult GetMeetings()
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\mssqllocaldb; Initial Catalog=Map;Integrated Security=true");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(@"Select A.Name as Name, Count(M.IdMeeting) as nbr, CONVERT(VARCHAR(10),M.MeetingDate,111) as meetingdate  from Meetings M , AspNetUsers A where M.IdAdministrator = A.id  Group By Name , CONVERT(VARCHAR(10),M.MeetingDate,111) ", con);
            
            DataTable dt = new DataTable();
           
            da.Fill(dt);

            List<GraphMeeting> lst = new List<GraphMeeting>();
            foreach (DataRow row in dt.Rows)
            {
                lst.Add(new GraphMeeting() { Name = row["Name"].ToString(), nbr = int.Parse(row["nbr"].ToString()) , med = row["meetingdate"].ToString()});
            }
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
    }

    public class GraphMeeting
    {
        public string Name { get; set; }
        public int nbr { get; set; }
        public string med { get; set; }

    }
}
    
