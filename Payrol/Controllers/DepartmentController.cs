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
        public DepartmentController(ApplicationDbContext db)
        {
            _db = db;
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
        public IActionResult Create(Department obj)
        {
            if(ModelState.IsValid)
            {
                _db.Department.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            else
            {
                return View(obj);
            }
            
        }

        //get- EDIT
        public IActionResult Edit (int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }

            var obj = _db.Department.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //[HttpPost]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Department obj)
        {
            if (ModelState.IsValid)
            {
                _db.Department.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            else
            {
                return View(obj);
            }

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Department.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST-DELETE
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Department.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Department.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}
