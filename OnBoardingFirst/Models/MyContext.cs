using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnBoardingFirst.Models
{
    public class MyContext:DbContext
    {

        public MyContext():base("Name = ContextConnection") { }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<ProductSold> ProductSold { get; set; }
    }
}