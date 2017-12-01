using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CS305_WebApp.Models;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace CS305_WebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RosterController : Controller
    {
        private ApplicationDbContext _dbContext;
        // GET: Roster
        public RosterController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var roster = _dbContext.Roster.ToList();
            return View(roster);
        }

        //Roster add method
        public ActionResult Add(RosterModel roster)
        {
            _dbContext.Roster.Add(roster);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Roster/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Roster/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roster/Create
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

        // GET: Roster/Edit/5
        public ActionResult Edit(int id)
        {
            var roster = _dbContext.Roster.SingleOrDefault(v => v.ID == id);

            if (roster == null)
                return HttpNotFound();

            return View(roster);
        }

        // POST: Roster/Edit/5
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
        [HttpPost]
        public ActionResult Update(RosterModel roster)
        {
            var rosterInDb = _dbContext.Roster.SingleOrDefault(v => v.ID == roster.ID);

            if (rosterInDb == null)
                return HttpNotFound();

            rosterInDb.Firstname = roster.Firstname;
            rosterInDb.Lastname = roster.Lastname;
            rosterInDb.description = roster.description;
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Roster/Delete/5
        public ActionResult Delete(int id)
        {
            var roster = _dbContext.Roster.SingleOrDefault(r => r.ID == id);

            if (roster == null)
                return HttpNotFound();
            return View(roster);
        }

        // POST: Roster/Delete/5
        
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
        
        public ActionResult DoDelete(int id)
        {
            var roster = _dbContext.Roster.SingleOrDefault(r => r.ID == id);
            if (roster == null)
                return HttpNotFound();
            _dbContext.Roster.Remove(roster);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        //Export to excel file
        public void ExportToExcel()
        {
            var grid = new GridView();
            StringWriter sw = new StringWriter();
            grid.DataSource = from data in _dbContext.Roster.ToList()
                              select new
                              {
                                  FirstName = data.Firstname,
                                  LastName = data.Lastname,
                                  Description = data.description
                              };
            grid.DataBind();

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename = ExportedRosterList.xls");
            Response.ContentType = "application/excel";

            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(sw);

            grid.RenderControl(htmlTextWriter);

            Response.Write(sw.ToString());

            Response.End();
        }
    }
}
