using CS305_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CS305_WebApp.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        private ApplicationDbContext _dbContext;
 
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
        public ActionResult ProgramView()
        {
            var program = _dbContext.programs.ToList();
            return View(program);
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

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            
            return View();
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
            var program = _dbContext.programs.SingleOrDefault(v => v.ID == id);

            if (program == null)
                return HttpNotFound();

            return View(program);
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
        //Update database
        [HttpPost]
        public ActionResult Update(ProgramModel program)
        {
            var programInDb = _dbContext.programs.SingleOrDefault(v => v.ID == program.ID);

            if (programInDb == null)
                return HttpNotFound();

            programInDb.name = program.name;
            programInDb.address = program.address;
            programInDb.number = program.number;
            programInDb.webpage = program.webpage;
            programInDb.keyword = program.keyword;
            _dbContext.SaveChanges();

            return RedirectToAction("ProgramView");
        }

        // GET: Search/Delete/5
        public ActionResult Delete(int id)
        {
            var program = _dbContext.programs.SingleOrDefault(r => r.ID == id);

            if (program == null)
                return HttpNotFound();
            return View(program);
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

        public ActionResult DoDelete(int id)
        {
            var program = _dbContext.programs.SingleOrDefault(r => r.ID == id);
            if (program == null)
                return HttpNotFound();
            _dbContext.programs.Remove(program);
            _dbContext.SaveChanges();
            return RedirectToAction("ProgramView");
        }
    }
}
