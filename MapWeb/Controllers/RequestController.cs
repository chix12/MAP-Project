using MapDomain.Entities;
using MapService;
using MapWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MapWeb.Controllers
{
    public class RequestController : Controller
    {
        RequestsService sr = new RequestsService();
        ProjectService ps = new ProjectService();
        // GET: Request
        public ActionResult Index()
        {
            
            var requests = sr.GetMany();
            return View(requests);
         
        }

        // GET: Request/Details/5
        public ActionResult Details(int id)
        {
            ClientRequestForm request = sr.GetById((long)id);
            RequestModel rm = new RequestModel();
            rm.Description = request.Description;
            rm.EndDate = request.EndDate;
            rm.Fees = request.Fees;
            rm.ProfileNeeded = request.ProfileNeeded;
            rm.Type = request.Type;
            rm.YearsOfExperience = request.YearsOfExperience;
            rm.IdProject = request.IdProject;

            return View(rm);
        }

        // GET: Request/Create
        public ActionResult Create()
        {
            RequestModel rm = new RequestModel();
          /*  rm.Projects = ps.GetMany().Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.IdProject.ToString()
            });*/
            return View();
        }

        // POST: Request/Create
        [HttpPost]
        public ActionResult Create(RequestModel rm)
        {
            try
            {
                // TODO: Add insert logic here
                ClientRequestForm request = new ClientRequestForm
                {
                    Type = rm.Type,
                    Fees = rm.Fees,
                    Description = rm.Description,
                    EndDate = rm.EndDate,
                    StartDate = rm.StartDate,
                    ProfileNeeded = rm.ProfileNeeded,
                    YearsOfExperience = rm.YearsOfExperience,
                    Requirements = rm.Requirements,                                   
                    
            };
                sr.Add(request);
                sr.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Request/Edit/5
        public ActionResult Edit(int? id)
        {
            ClientRequestForm request = sr.GetById((long)id);
            RequestModel rm = new RequestModel();
            rm.Description = request.Description;
            rm.EndDate = request.EndDate;
            rm.Fees = request.Fees;
            rm.ProfileNeeded = request.ProfileNeeded;
            rm.Type = request.Type;
            rm.YearsOfExperience = request.YearsOfExperience;
            rm.IdProject = request.IdProject;

            return View(rm);
        }

        // POST: Request/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var studentToUpdate = sr.GetById((long)id);
            if (TryUpdateModel(studentToUpdate, "",
               new string[] { "Fees", "Description", "YearsOfExperience" }))
            {
                try
                {
                    sr.Commit();

                    return RedirectToAction("Index");
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(studentToUpdate);
        }

        // GET: Request/Delete/5
        public ActionResult Delete(int id)
        {
            ClientRequestForm request = sr.GetById((long)id);
            RequestModel rm = new RequestModel();
            rm.Description = request.Description;
            rm.EndDate = request.EndDate;
            rm.Fees = request.Fees;
            rm.ProfileNeeded = request.ProfileNeeded;
            rm.Type = request.Type;
            rm.YearsOfExperience = request.YearsOfExperience;
            rm.IdProject = request.IdProject;

            return View(rm);                        
        }

        // POST: Request/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, RequestModel rm)
        {
            try
            {
                ClientRequestForm Request = sr.GetById((long)id);
                sr.Delete(Request);
                sr.Commit();
            }
            catch (DataException/* dex */s)
            {
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}
