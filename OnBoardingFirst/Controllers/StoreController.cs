using OnBoardingFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnBoardingFirst.Controllers
{
    public class StoreController : Controller
    {
        private MyContext db = new MyContext(); 
        // GET: Store
        public ActionResult Index()
        {
            return View(db.Store.ToList());
        }


        [HttpPost]
        public ActionResult Create(Store store)
        {

            var name = store.Name;
            var address = store.Address;
            var newStore = new Store {  Name = name, Address = address };
            db.Store.Add(newStore);
            db.SaveChanges();
            return RedirectToAction("Index", "Store");

        }

        public ActionResult Delete(int? id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store storeInDB = db.Store.Single(i => i.ID == id);
            if (storeInDB == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(storeInDB);
        }


        [HttpPost]
        public ActionResult DeleteConfirm(Store store)
        {
            if (store.ID == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store storeInDB = db.Store.Single(i => i.ID == store.ID);
            db.Store.Remove(storeInDB);
            db.SaveChanges();
            return RedirectToAction("Index", "Store");
        }
    }
}