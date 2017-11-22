using CS305_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CS305_WebApp.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        private ApplicationDbContext _dbContext;
        private ProgramsDBContext db = new ProgramsDBContext();
        public SearchController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Index(string searchString)
        {
            var pro = from p in _dbContext.programs
                      select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                pro = pro.Where(s => s.keyword.Contains(searchString));
                   
                
            }

            return View(pro);
        }
        [HttpGet]
        public ActionResult Search(string searchString)
        {
            var pro = from p in _dbContext.programs
                      select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                pro = pro.Where(s => s.name.Contains(searchString));
            }

            return RedirectToAction("Index", pro);
        }

        public ActionResult Add(ProgramModel program)
        {
            _dbContext.programs.Add(program);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Search/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Search/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Search/Create
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

        // GET: Search/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Search/Edit/5
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

        // GET: Search/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Search/Delete/5
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
