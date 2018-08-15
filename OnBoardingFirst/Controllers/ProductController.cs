using OnBoardingFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnBoardingFirst.Controllers
{
    public class ProductController : Controller
    {

        private MyContext db = new MyContext();
        // GET: Product
        public ActionResult Index()
        {
            return View(db.Product.ToList());
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {

            var name = product.Name;
            var price = product.Price;
            var newProduct = new Product {  Name = name, Price = price };
            db.Product.Add(newProduct);
            db.SaveChanges();
            return RedirectToAction("Index", "Product");

        }

        public ActionResult Delete(int? id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product productInDB = db.Product.Single(i => i.ID == id);
            if (productInDB == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(productInDB);
        }


        [HttpPost]
        public ActionResult DeleteConfirm(Product Product)
        {
            if (Product.ID == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product productInDB = db.Product.Single(i => i.ID == Product.ID);
            db.Product.Remove(productInDB);
            db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
    }
}