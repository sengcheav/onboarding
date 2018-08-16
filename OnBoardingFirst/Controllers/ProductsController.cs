using OnBoardingFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnBoardingFirst.Controllers
{

    /*Product(s) controller using ajax and ko validation 
     * while Product(without s ) using just MVC and jquery validation 
     
         
         */ 


    public class ProductsController : Controller
    {
        private MyContext db = new MyContext(); 

        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetProductsList()
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Product> ProductList = db.Product.ToList();
            return Json(ProductList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddProduct( Product p)
        {

            Product product = new Product
            {
                Name = p.Name,
                Price = p.Price
            };
            db.Product.Add(product);
            db.SaveChanges();
            return Json(new { success = true, responseText = "Record Successful Added!" });
        }

        [HttpGet]
        public ActionResult GetByID( int id)
        {

            db.Configuration.ProxyCreationEnabled = false;
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound); 
            }
            Product p = db.Product.SingleOrDefault(m => m.ID == id);
            return Json(p, JsonRequestBehavior.AllowGet);
        }

       

        [HttpPost]
        public ActionResult UpdateByID(Product product)
        {

            if( product.ID == 0 )
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); 
            }
            Product productInDB = db.Product.SingleOrDefault(p => p.ID == product.ID);
            if(productInDB == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }else
            {
                productInDB.Name = product.Name;
                productInDB.Price = product.Price;
                db.SaveChanges();
                return Json(new { success = true, responseText = "Record Successful Updated!" });
            }

        }

        [HttpPost]
        public ActionResult DeleteByID(int id) {
            if( id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); 
            }


            Product productInDB = db.Product.SingleOrDefault(p => p.ID == id);
            if ( productInDB == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }else
            {
                db.Product.Remove(productInDB);
                db.SaveChanges(); 
                return Json(new { success = true, responseText = "Record Successful Deleted!" });

            }

        }
    }
}