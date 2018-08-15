using OnBoardingFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnBoardingFirst.Controllers
{
    public class CustomerController : Controller
    {
        private MyContext db = new MyContext();
        // GET: Customer
        public ActionResult Index()
        {
            return View(db.Customer.ToList());
        }

        

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
           
            var name = customer.Name;
            var address =customer.Address; 
            var newCustomer  = new Customer {  Name =  name, Address = address};
            db.Customer.Add(newCustomer);
            db.SaveChanges(); 
            return RedirectToAction("Index", "Customer"); 

        }

        
        public ActionResult Edit( int? id)
        {
            var customer = db.Customer.SingleOrDefault(c => c.ID == id);
            if(customer == null)
            {
                return HttpNotFound();
            }
            return View(customer); 

        }

        
        public ActionResult Update(Customer customer)
        {
            if (customer.ID == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var customerInDb = db.Customer.Single(c => c.ID == customer.ID);
                customerInDb.Name = customer.Name;
                customerInDb.Address = customer.Address;

            }
            db.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }


        public ActionResult Delete(int? id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customerInDB = db.Customer.Single(i => i.ID == id);
            if (customerInDB == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(customerInDB);
        }


        [HttpPost]
        public ActionResult DeleteConfirm(Customer customer)
        {
            if (customer.ID == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customerInDB = db.Customer.Single(i => i.ID == customer.ID);
            db.Customer.Remove(customerInDB);
            db.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

    }
}