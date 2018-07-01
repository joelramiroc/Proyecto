using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CSales.Database.Contexts;
using CSales.Database.Models;
using ProjectSalesCore.ViewModel.Employee;

namespace ProjectSalesCore.Controllers
{
    public class EmployeesController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Employee.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Employee employee = db.Employee.Find(id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            var ne = new DetailEmployeeViewModel {
                Id = employee.Id,
                Addresses = this.db.AddressEmployee.Where(a=>a.IdEMP == employee.Id),
                HireDate = employee.HireDate,
                Name = employee.Name,
                Salary = employee.Salary,
                Telephones = this.db.TelephoneEmployee.Where(t => t.IdEMP == employee.Id)
            };

            return View(ne);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View(new CreateEmployeeViewModel());
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateEmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                var e = new Employee
                {
                    HireDate = employee.HireDate,
                    Name = employee.Name,
                    Salary = employee.Salary
                };

                var ne = db.Employee.Add(e);
                db.SaveChanges();

                for (int i = 0; i < employee.Addresses.Count(); i++)
                {
                    this.db.Database.ExecuteSqlCommand(@"INSERT INTO AEMP(ADDRESSNAME,DESCRIPTION,IDEMP) values ({0},{1},{2})", employee.Addresses.ElementAt(i), "Descripcion default", ne.Id);
                }

                for (int i = 0; i < employee.Telephones.Count(); i++)
                {
                    this.db.Database.ExecuteSqlCommand(@"INSERT INTO TELEMP(NUMBER,DESCRIPTION,IDEMP) values ({0},{1},{2})", employee.Telephones.ElementAt(i), "Descripcion default", ne.Id);
                }

                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,HireDate,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employee.Find(id);
            db.Employee.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
