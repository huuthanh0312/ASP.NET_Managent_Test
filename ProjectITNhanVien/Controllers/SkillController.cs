using ProjectITNhanVien.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectITNhanVien.Controllers
{
    public class SkillController : Controller
    {
        private DBContext db = new DBContext();
        // GET: Skill
        public ActionResult Index()
        {
            var skill = db.Skills.ToList();
            return View(skill);
        }

        // GET: Skill/Details/5
        public ActionResult Details(int id)
        {
            var skill = db.Skills.Find(id);
            return View(skill);
        }

        // GET: Skill/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Skill/Create
        [HttpPost]
        public ActionResult Create(Skill skill)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    db.Skills.Add(skill);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Skill/Edit/5
        public ActionResult Edit(int id)
        {
            var skill = db.Skills.Find(id);
            return View(skill);
        }

        // POST: Skill/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Skill skill)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(skill).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(skill);
            }
            catch
            {
                return View(skill);
            }
        }

        // GET: Skill/Delete/5
        public ActionResult Delete(int id)
        {
            var skill = db.Skills.Find(id);
            return View(skill);
        }

        // POST: Skill/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            try
            {
                Skill skill = db.Skills.Find(id);
                db.Skills.Remove(skill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
