using OnBoardingFirst.Models;
using OnBoardingFirst.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnBoardingFirst.Controllers
{
    public class ProductSoldController : Controller
    {
        private MyContext db = new MyContext();
        // GET: PSold
        public ActionResult Index()
        {

            List<ProductSold> PsoldList = db.ProductSold.ToList();
            List<Customer> CustomerList = db.Customer.ToList();
            List<Product> ProductList = db.Product.ToList();
            List<Store> StoreList = db.Store.ToList();

            List<RecordModel> RecordModelList = new List<RecordModel>() ;

            

            foreach (var psold in PsoldList)
            {

                Customer c = CustomerList.Single(s => s.ID == psold.CustomerID); // find the customer in customerlist correspond to the CustomerID in ProductSold
                Product p = ProductList.Single(s => s.ID == psold.ProductID);
                Store st = StoreList.Single(s => s.ID == psold.StoreID);
                ProductSold ps = psold;

                RecordModel RecordModel = new RecordModel
                {
                    Customer = c,
                    Product = p,
                    Store = st,
                    ProductSold = ps
                };
                RecordModelList.Add(RecordModel); 
            }
            PSoldViewModel PSoldViewModel = new PSoldViewModel
            {
                Customers = CustomerList,
                Products = ProductList,
                Stores = StoreList,
                ProductSolds = PsoldList,
                RecordList = RecordModelList
            };
            return View(PSoldViewModel);
        }


        [HttpPost]
        public ActionResult Create(PSoldViewModel psm)
        {

            var cid = psm.Customers[0].ID;
            var pid = psm.Products[0].ID;
            var sid = psm.Stores[0].ID; 

           // var customerID= psold.CustomerID;
            //var productID = psold.ProductID;
            //var datesold  = psold.DateSold;
           // var storeID = psold.StoreID;
            var Date = DateTime.Today; 
            
            //var newPSold = new ProductSold { CustomerID = customerID, ProductID = productID, StoreID= storeID , DateSold = Date};.
            var newPSold = new ProductSold { CustomerID = cid, ProductID = pid, StoreID = sid, DateSold = Date };
            db.ProductSold.Add(newPSold);
            db.SaveChanges();
            return RedirectToAction("Index", "ProductSold");



        }

        public ActionResult Delete(int? id)
        {
            if(id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSold psoldInDB = db.ProductSold.Single(i => i.ID == id);
            if (psoldInDB == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(psoldInDB); 
        }


        [HttpPost]
        public ActionResult DeleteConfirm(ProductSold psold)
        {
            if ( psold.ID == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSold psoldInDB = db.ProductSold.Single(i => i.ID == psold.ID);
            db.ProductSold.Remove(psoldInDB);
            db.SaveChanges();
            return RedirectToAction("Index", "ProductSold"); 
        }

    }
}