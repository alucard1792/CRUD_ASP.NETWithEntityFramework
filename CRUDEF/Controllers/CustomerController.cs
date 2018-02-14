using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CRUDEF.Models;

namespace CRUDEF.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            using (DbModels dbModels= new DbModels())
            {
                return View(dbModels.Customers.ToList());

            }
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels dbModels = new DbModels())
            {
            return View(dbModels.Customers.Where(x => x.Id == id).First());

            }
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {
                    dbModel.Customers.Add(customer);
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels dbModels = new DbModels())
            {
                return View(dbModels.Customers.Where(x => x.Id == id).First());

            }

        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                using (DbModels dbModels = new DbModels())
                {
                    dbModels.Entry(customer).State = EntityState.Modified;
                    dbModels.SaveChanges();
                    return RedirectToAction("Index");

                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            //copiado de edit()
            using (DbModels dbModels = new DbModels())
            {
                return View(dbModels.Customers.Where(x => x.Id == id).First());

            }
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DbModels dbModels = new DbModels())
                {
                    Customer customer = dbModels.Customers.Where(x => x.Id == id).First();
                    dbModels.Customers.Remove(customer);
                    dbModels.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
