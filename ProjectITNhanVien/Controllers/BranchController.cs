using ProjectITNhanVien.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectITNhanVien.Controllers
{
    public class BranchController : Controller
    {
        private DBContext db = new DBContext();
        // GET: Branch
        public ActionResult Index()
        {
            var branch = db.Branches.ToList();
            return View(branch);
        }

        // GET: Branch/Details/5
        public ActionResult Details(int id)
        {
            // k sài 2 cái này hhh biết mô chút t sửa lại, mà chạy được thì thôi, haha tutu t đi dái ok
            var branch = db.Branches.Find(id);
            return View(branch);
        }

        // GET: Branch/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Branch/Create
        [HttpPost]
        public ActionResult Create(Branch branch)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    db.Branches.Add(branch);
                    return RedirectToAction("Index");
                }
                return View();
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Branch/Edit/5
        public ActionResult Edit(int id)
        {
            var branch = db.Branches.Find(id);
            return View(branch);
        }

        // POST: Branch/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Branch branch)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(branch).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(branch);
            }
            catch
            {
                return View(branch);
            }
        }

        // GET: Branch/Delete/5
        public ActionResult Delete(int id)
        {
            var branch = db.Branches.Find(id);
            return View(branch);
        }

        // POST: Branch/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var check = db.Employees.Where(o => o.BranchID.Equals(id));
                if(check == null)
                {
                    Branch branch = db.Branches.Find(id);
                    db.Branches.Remove(branch);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Chi Nhánh Tồn Tại Nhân Viên Vui Lòng Không Xoá Chi Nhánh Này!";
                    return View();
                }
                // TODO: Add delete logic here
                
            }
            catch
            {
                return View();
            }
        }
    }
}
