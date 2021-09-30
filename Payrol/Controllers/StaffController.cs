using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payrol.Data;
using Payrol.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Payrol.Controllers
{

    public class StaffController  : Controller
    {
        private readonly ApplicationDbContext _db;

        public StaffController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            IEnumerable<Staff> objlist = _db.Staff;

            var SalaryViewModel = _db.Staff.Include(x => x.Department).ToList();

            return View(SalaryViewModel);
        }



        //get- CREATE
        public IActionResult Create()
        {

            List<Department> departments = new List<Department>();

            departments = _db.Department.ToList();
            departments.Insert(0, new Department { DepartmentId = 0, DepartmentName = "--Select Department Name--" });

            ViewBag.message = departments;

            return View();
        }

        //post - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Staff staff)
        {
            if (ModelState.IsValid)
            {
                _db.Staff.Add(staff);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            else
            {
                return View(staff);
            }

        }

        //get- EDIT
        
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Staff.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            List<Department> departments = new List<Department>();
            departments = _db.Department.ToList();
            departments.Insert(0, new Department { DepartmentId = 0, DepartmentName = "--Select Department Name--" });

            ViewBag.message = departments;

            return View(obj);
        }

        //post - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Staff staff)
        {
            if (ModelState.IsValid)
            {
                _db.Staff.Update(staff);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            else
            {
                return View(staff);
            }

        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var FindStaffId = _db.Staff.Find(id);
            if (FindStaffId == null)
            {
                return NotFound();
            }
            List<Department> departments = new List<Department>();
            departments = _db.Department.ToList();
            departments.Insert(0, new Department {DepartmentId = 0, DepartmentName = "--Select Department Name--" });

            ViewBag.message = departments;

            return View(FindStaffId);
        }

        //POST-DELETE
        public IActionResult DeletePost(int? id)
        {
            var FindStaffId = _db.Staff.Find(id);
            if (FindStaffId == null)
            {
                return NotFound();
            }

            _db.Staff.Remove(FindStaffId);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
