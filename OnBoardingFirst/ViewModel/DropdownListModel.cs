using OnBoardingFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnBoardingFirst.ViewModel
{
    public class DropdownListModel
    {
        public List<Customer> Customers { get; set; }
        public List<Product> Products { get; set; }
        public List<Store> Stores { get; set; }

    }
}