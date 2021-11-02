using ProjectITNhanVien.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjectITNhanVien.Controllers
{
    public class EmployeeController : Controller
    {
        private DBContext db = new DBContext();
        // GET: Employee
        public ActionResult Index()
        {
            var result = (from e in db.Employees
                          from s in e.Skills
                          join c in db.Skills on s.SkillID equals c.SkillID
                          select new EmployeeSkill
                          {
                              EmployeeID = e.EmployeeID,
                              SkillID = c.SkillID,
                              SkillName = c.SkillName
                          }).ToList();

            ViewBag.EmployeeSkill = result;
            var employee = db.Employees.ToList();
            return View(employee);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.SelectListBranch = db.Branches.ToList();
            
            var result = (from e in db.Employees
                          from s in e.Skills
                          join c in db.Skills on s.SkillID equals c.SkillID
                          where e.EmployeeID == id
                          select new EmployeeSkill
                          {
                              SkillID= c.SkillID,
                              SkillName = c.SkillName
                          }).ToList();
            
            ViewBag.EmployeeSkill = result;
            var employee = db.Employees.Find(id);
            return View(employee);
        }
        // GET: Employee/Create
        public ActionResult Create()
        {
            ViewBag.SelectListBranch = db.Branches.ToList();
            ViewBag.Skills = db.Skills.ToList();
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(long[] SkillID, Employee employee)
        {
            try
            {

                // TODO: Add insert logic here
                if (SkillID != null)
                {
                    foreach (var skillid in SkillID)
                    {
                        Skill skill = db.Skills.Where(d => d.SkillID == skillid).First();

                        employee.Skills.Add(skill);
                    }
                }
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            List<Branch> branchList = db.Branches.ToList();
            ViewBag.SelectListBranch = branchList;
            
            var result = (from e in db.Employees
                          from s in e.Skills
                          join c in db.Skills on s.SkillID equals c.SkillID
                          where e.EmployeeID == id
                          select new EmployeeSkill
                          {
                              SkillID = c.SkillID,
                              SkillName = c.SkillName
                          }).ToList();

            ViewBag.EmployeeSkill = result;
            ViewBag.Skills = db.Skills.ToList();
            var employee = db.Employees.Find(id);
            return View(employee);
            
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee employee, long[] SkillID)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var result = (from e in db.Employees
                                  from s in e.Skills
                                  join c in db.Skills on s.SkillID equals c.SkillID
                                  where e.EmployeeID == id
                                  select new EmployeeSkill
                                  {
                                      SkillID = c.SkillID,
                                      SkillName = c.SkillName
                                  }).ToList();
                    Employee employee1 = db.Employees.Find(id);
                    foreach (var oldSkill in result)
                    {
                        var skill = db.Skills.FirstOrDefault(s => s.SkillID == oldSkill.SkillID);
                        employee1.Skills.Remove(skill);
                        
                    }
                    foreach (var skillid in SkillID)
                    {
                        Skill skill = db.Skills.Where(d => d.SkillID == skillid).First();

                        employee1.Skills.Add(skill);
                        

                    }
                    db.Entry(employee).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                else
                {
                    return Content("0");
                }
            }
            catch
            {
                return View(employee);
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.SelectListBranch = db.Branches.ToList();
            //var employee = (from s in db.Skills.Where(s => s.Employees.Any())
            //                    from e in db.Employees.Where(e => e.Skills.Contains(s)&& )
            //                    select new { e.EmployeeID,e.Name, e.BirthDate, e.Address, e.Joining_Date, e.Notes, s.SkillID, s.SkillName  });
            //var employee = db.Employees.Find(id);
            var result = (from e in db.Employees
                          from s in e.Skills
                          join c in db.Skills on s.SkillID equals c.SkillID
                          where e.EmployeeID == id
                          select new EmployeeSkill
                          {
                              SkillID = c.SkillID,
                              SkillName = c.SkillName
                          }).ToList();

            ViewBag.EmployeeSkill = result;
            var employee = db.Employees.Find(id);
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                
                Employee employee = db.Employees.Find(id);
                var result = (from e in db.Employees
                              from s in e.Skills
                              join c in db.Skills on s.SkillID equals c.SkillID
                              where e.EmployeeID == id
                              select new EmployeeSkill
                              {
                                  SkillID = c.SkillID,
                                  SkillName = c.SkillName
                              }).ToList();
                foreach (var oldSkill in result)
                    {
                        var skill = db.Skills.FirstOrDefault(s => s.SkillID == oldSkill.SkillID);
                        employee.Skills.Remove(skill);
                    }
                db.Employees.Remove(employee);
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
