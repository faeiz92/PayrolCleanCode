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

        public StaffController(ApplicationDbContext ObjectDb)
        {
            _db = ObjectDb;
        }
        public IActionResult Index()
        {

            IEnumerable<Staff> staff = _db.Staff;

            var SalaryViewModel = _db.Staff.Include(x => x.Department).ToList();

            return View(SalaryViewModel);
        }



        //get- CREATE
        public IActionResult Create()
        {

            List<Department> departments = new List<Department>();

            departments = _db.Department.ToList();
            departments.Insert(0, new Department { DepartmentId = 0, DepartmentName = "--Select Department Name--" });

            ViewData["departments"] = departments;

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

            var DataStaff = _db.Staff.Find(id);
            if (DataStaff == null)
            {
                return NotFound();
            }

            List<Department> departments = new List<Department>();
            departments = _db.Department.ToList();
            departments.Insert(0, new Department { DepartmentId = 0, DepartmentName = "--Select Department Name--" });

            ViewData["departments"] = departments;

            return View(DataStaff);
        }

        //post - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Staff ObjectStaff)
        {
            if (ModelState.IsValid)
            {
                _db.Staff.Update(ObjectStaff);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            else
            {
                return View(ObjectStaff);
            }

        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var StaffId = _db.Staff.Find(id);
            if (StaffId == null)
            {
                return NotFound();
            }
            List<Department> departments = new List<Department>();
            departments = _db.Department.ToList();
            departments.Insert(0, new Department {DepartmentId = 0, DepartmentName = "--Select Department Name--" });

            ViewData["departments"] = departments;

            return View(StaffId);
        }

        //POST-DELETE
        public IActionResult DeletePost(int? id)
        {
            var StaffId = _db.Staff.Find(id);
            if (StaffId == null)
            {
                return NotFound();
            }

            _db.Staff.Remove(StaffId);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
