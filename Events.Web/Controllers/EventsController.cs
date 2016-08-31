using Events.Data;
using Events.Web.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Events.Web.Controllers
{
    public class EventsController : BaseController
    {
        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventInputModel model)
        {
            if(model != null && this.ModelState.IsValid)
            {
                var e = new Event()
                {
                    AuthorId = this.User.Identity.GetUserId(),
                    Title = model.Title,
                    StartDateTime = model.StartDateTime,
                    Duration = model.Duration,
                    Location = model.Location,
                    IsPublic = model.IsPublic,
                    Description = model.Description
                };
                this.db.Events.Add(e);
                this.db.SaveChanges();
                //Display notification message "Event created."
                return this.RedirectToAction("My");
            }

            return this.View(model);
        }

        // GET: Events/My
        public ActionResult My()
        {
            return View();
        }
    }
}