using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnBoardingFirst.Models
{
    public class ProductSoldInit: DropCreateDatabaseIfModelChanges<MyContext>
    {

        protected override void Seed(MyContext context)
        {
            var customer1 = new Customer { ID = 1, Name = "Seng" };
           


            var product111 = new Product { ID = 111, Name = "Fruit", Price = 9.5F };


            var store1 = new Store { ID = 1, Name = "New World" };

            context.Customer.Add(customer1);
            
            context.Product.Add(product111);
            context.Store.Add(store1);
            context.SaveChanges();

            var productSold1 = new ProductSold { ID = 1, CustomerID = 1, ProductID = 111, StoreID = 1, DateSold = DateTime.Now };
            context.ProductSold.Add(productSold1);
            context.SaveChanges();




        }
    }
}