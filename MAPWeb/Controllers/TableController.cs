using MapService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using MapDomain.Entities;
using MapWeb.Models;

namespace MapWeb.Controllers
{
    public class TableController : HomeController
    {

        RessourceService rs = new RessourceService();


        // GET: Table
        public ActionResult Table(string search, int? i)
        {


            var Ressource = rs.GetMany(p => p.Email.Contains(search) ||
                                            p.UserName.Contains(search) ||
                                            p.ProfileT.Contains(search) ||
                                            p.Seniority.Contains(search)

                );

            return View(Ressource.ToList().ToPagedList(i ?? 1, 3));
        }

        /*

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

    }*/




        // GET: Resource/Edit/5
        public ActionResult Edit2(int id)
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

    }
}