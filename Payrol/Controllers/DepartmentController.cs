using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payrol.Data;
using Payrol.Models;

namespace Payrol.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly ApplicationDbContext _db;
        public DepartmentController(ApplicationDbContext ObjectDb)
        {
            _db = ObjectDb;
        }
        public IActionResult Index()
        {
            IEnumerable<Department> departments = _db.Department;
            return View(departments);
        }

        //get- CREATE
        public IActionResult Create()
        {
            
            return View();
        }

        //post - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {
            if(ModelState.IsValid)
            {
                _db.Department.Add(department);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            else
            {
                return View(department);
            }
            
        }

        //get- EDIT
        public IActionResult Edit (int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }

            var DepartmentId = _db.Department.Find(id);
            if(DepartmentId == null)
            {
                return NotFound();
            }

            return View(DepartmentId);
        }

        //[HttpPost]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _db.Department.Update(department);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            else
            {
                return View(department);
            }

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var DepartmentId = _db.Department.Find(id);
            if (DepartmentId == null)
            {
                return NotFound();
            }

            return View(DepartmentId);
        }

        //POST-DELETE
        public IActionResult DeletePost(int? id)
        {
            var DepartmentId = _db.Department.Find(id);
            if (DepartmentId == null)
            {
                return NotFound();
            }

            _db.Department.Remove(DepartmentId);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}
