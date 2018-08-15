using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public class SaleController : Controller
    {
        private MyContext db = new MyContext();
        // GET: Sale
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult RecoredModelList()
        {
            List<ProductSold> PsoldList = db.ProductSold.ToList();
            List<Customer> CustomerList = db.Customer.ToList();
            List<Product> ProductList = db.Product.ToList();
            List<Store> StoreList = db.Store.ToList();
            List<Psoldsimplify> PsoldSimplifyList = new List<Psoldsimplify>(); 
            foreach (var psold in PsoldList)
            {               
                Customer c = CustomerList.Single(s => s.ID == psold.CustomerID); // find the customer in customerlist correspond to the CustomerID in ProductSold
                Product p = ProductList.Single(s => s.ID == psold.ProductID);
                Store st = StoreList.Single(s => s.ID == psold.StoreID);
                ProductSold ps = psold;

                Psoldsimplify PSoldSimplify = new Psoldsimplify
                {
                    CustomerID = c.ID,
                    CustomerName = c.Name,

                    ProductID = p.ID,
                    ProductName = p.Name,
                    ProductPrice = p.Price,

                    StoreID = st.ID,
                    StoreName = st.Name,

                    ProductSoldID = ps.ID,
                    ProductSoldDate = ps.DateSold

                };
                PsoldSimplifyList.Add(PSoldSimplify); 
            }           
            return Json(PsoldSimplifyList, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult DropdownList()
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Customer> CustomerList = db.Customer.ToList();
            List<Product> ProductList = db.Product.ToList();
            List<Store> StoreList = db.Store.ToList();

            DropdownListModel dropdownModel = new DropdownListModel
            {
                Customers = CustomerList,
                Products = ProductList,
                Stores = StoreList
            };

            return Json(dropdownModel, JsonRequestBehavior.AllowGet); 


        }

        [HttpPost]
        public ActionResult AddRecord(ProductSold ps)
        {
            ProductSold newProductSold = new ProductSold
            {
                CustomerID = ps.CustomerID,
                StoreID = ps.StoreID,
                ProductID = ps.ProductID,
                DateSold = DateTime.Today

            };
            db.ProductSold.Add(newProductSold);
            db.SaveChanges();

            return Json(new { success = true, responseText = "Record Successful Added!" }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult delete(int id)
        {

            ProductSold psInDB = db.ProductSold.SingleOrDefault(ps => ps.ID == id);
            if(psInDB == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            }
            else
            {
                db.ProductSold.Remove(psInDB);
                db.SaveChanges(); 
                return Json(new { success = true, responseText = "Record Successful Deleted!" }, JsonRequestBehavior.AllowGet);
            }

        }

    }
}