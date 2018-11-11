using MapDomain.Entities;
using MapService;
using MapWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
           return View();
        }

        // GET: Request/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Request/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Request/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Request/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
