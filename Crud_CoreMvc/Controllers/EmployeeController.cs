using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crud_CoreMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud_CoreMvc.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext dbContext;
        public EmployeeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var data = dbContext.employees.ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee e)
        {
            if (ModelState.IsValid)
            {
                dbContext.employees.Add(e);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            var del = dbContext.employees.SingleOrDefault(e => e.Id == id);
            dbContext.employees.Remove(del);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var ed = dbContext.employees.SingleOrDefault(e => e.Id == id);
            return View(ed);
        }
        [HttpPost]
        public IActionResult Edit(Employee e)
        {
            dbContext.employees.Update(e);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
