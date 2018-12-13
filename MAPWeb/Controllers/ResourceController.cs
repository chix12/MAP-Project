using MapDomain.Entities;
using MapService;
using MapWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MapWeb.Controllers
{
    public class ResourceController : Controller
    {
        RessourceService rs = new RessourceService();
        // GET: Resource
        public ActionResult Index()
        {
            return View();
        }

        // GET: Resource/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Resource/Create
        public ActionResult Create()
        {
            ResourceModel rm = new ResourceModel();
            rm.Profiles = rs.GetMany().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.ProfileT.ToString(),
            });
            return View(rm);
        }

        // POST: Resource/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Resource/Edit/5
        public ActionResult Edit(int id)
        {
            //if(id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Ressource p = rs.GetById(id);
            //if (p == null)
            //{
            //    //return HttpNotFound();
            //    return View();
            //}
            ResourceModel pm = new ResourceModel();
            pm.Name = p.UserName;
            pm.ProfileT = p.ProfileT;
            pm.Seniority = p.Seniority;
            pm.Email = p.Email;


            return View(pm);
        }

        // POST: Resource/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ResourceModel pm)
        {

            try
            {
                // TODO: Add update logic here
                Ressource p1 = rs.GetById(id);
                p1.Name = pm.Name;
                p1.ProfileT = pm.ProfileT;
                p1.Seniority = pm.Seniority;
                p1.Email = pm.Email;
                //p1.ProjectPicture = pm.ProjectPicture;
                rs.Update(p1);
                rs.Commit();

                /*
                MailMessage mail = new MailMessage("omar.dagdoug@esprit.tn", "mo.ni.a@live.com", "compte modifié cree ", " your Account is updated ");
                SmtpClient client = new SmtpClient("Smtp.gmail.com");
                client.Port = 25;
                client.Credentials = new System.Net.NetworkCredential("omar.dagdoug@esprit.tn", "OMAR.DAGDOUG.1407");
                client.EnableSsl = true;
                client.Send(mail);

                */
                return RedirectToAction("Index2");
            }
            catch (Exception ex)
            {
                return View(pm);
            }
        }


        public ActionResult Index2()
        {
            var Ressource = rs.GetMany();
            return View(Ressource);
        }

        [HttpPost]
        public ActionResult Index2(string searchString)
        {
            // var Products = sp.GetMany(p=>p.Name == searchString);
            var Resources = rs.GetMany(p => p.Email.Contains(searchString) ||
                                            p.UserName.Contains(searchString) ||
                                            p.ProfileT.Contains(searchString) ||
                                            p.Seniority.Contains(searchString)
                                       );
            return View(Resources);
        }


        // GET: Project/Delete/5
        public ActionResult Delete2(int id)
        {
            Ressource p = rs.GetById(id);
            ResourceModel rs1 = new ResourceModel();
            rs1.Name = p.Name;
            rs1.Rating = p.Rating;
            rs1.CurriculumVitae = p.CurriculumVitae;
        

            return View(rs1);
        }

        // POST: Project/Delete/5
        [HttpPost]
        public ActionResult Delete2(int id, ResourceModel pm)
        {
            try
            {
                // TODO: Add delete logic here
                Ressource p = rs.GetById(id);
                rs.Delete(p);
                rs.Commit();

                return RedirectToAction("Index2");
            }
            catch
            {
                return View();
            }
        }



    }
}
