using OnBoardingFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnBoardingFirst.Controllers
{
    public class StoresController : Controller
    {
        private MyContext db = new MyContext();

       
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetStoresList()
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Store> StoreList = db.Store.ToList();
            return Json(StoreList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddStore(Store st)
        {

            Store store = new Store
            {
                Name = st.Name,
                Address= st.Address
            };
            db.Store.Add(store);
            db.SaveChanges();
            return Json(new { success = true, responseText = "Record Successful Added!" });
        }

        [HttpGet]
        public ActionResult GetByID(int id)
        {

            db.Configuration.ProxyCreationEnabled = false;
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            Store st = db.Store.SingleOrDefault(m => m.ID == id);
            return Json(st, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult UpdateByID(Store store)
        {

            if (store.ID == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store storeInDB = db.Store.SingleOrDefault(st => st.ID == store.ID);
            if (storeInDB == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                storeInDB.Name = store.Name;
                storeInDB.Address = store.Address;
                db.SaveChanges();
                return Json(new { success = true, responseText = "Store Successful Updated!" });
            }

        }

        [HttpPost]
        public ActionResult DeleteByID(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            Store storeInDB = db.Store.SingleOrDefault(st => st.ID == id);
            if (storeInDB == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                db.Store.Remove(storeInDB);
                db.SaveChanges();
                return Json(new { success = true, responseText = "Record Successful Deleted!" });

            }

        }
    }
}