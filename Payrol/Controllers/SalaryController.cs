using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payrol.Data;
using Payrol.Models;
using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Payrol.Controllers
{

    public class SalaryController  : Controller
    {
        
        private readonly ApplicationDbContext _db;

        public SalaryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Salary> salary =  _db.Salary;

            var salaryViewModel = _db.Salary.Include(x=> x.Staff).Include(x => x.Staff.Department).ToList();

            return View(salaryViewModel);
        }


        public IActionResult ViewSalary(int SalaryStaffId, int SalaryId)
        { 

            IEnumerable<Salary> objlist = _db.Salary;

            var salaryViewModel = _db.Salary.Where(x => x.SalaryId == SalaryId).Include(x => x.Staff).Include(x => x.Staff.Department).FirstOrDefault(x => x.SalaryStaffId == SalaryStaffId);
            
            ViewBag.Total = _db.Salary.Where(x => x.SalaryId == SalaryId).Sum(x => x.SalaryBasic + x.SalaryTransportAllowance + x.SalaryPerformanceAllowance + x.SalaryOvertime + x.SalaryKwsp);

            return View(salaryViewModel);
        }



        //get- CREATE()
        public IActionResult Create()
        {
            List<Staff> staffs = new List<Staff>();
            staffs = _db.Staff.ToList(); ;
            staffs.Insert(0, new Staff { StaffId = 0, StaffName = "--Select Staff Name--" });

            ViewBag.message = staffs;

            return View();
        }

        //post - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Salary salary)
        {
            if (ModelState.IsValid)
            {
                _db.Salary.Add(salary);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            else
            {
                return View(salary);
            }

        }

        //get- EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Salary.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //post - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Salary salary)
        {
            if (ModelState.IsValid)
            {
                _db.Salary.Update(salary);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            else
            {
                return View(salary);
            }

        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Salary.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST-DELETE
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Salary.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Salary.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
