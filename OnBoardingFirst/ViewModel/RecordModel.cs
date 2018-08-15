using OnBoardingFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnBoardingFirst.ViewModel
{


    // RecordModel is a class that will Find the Customer Object ,Store Object,Product object by using ID of each object in ProductSold( customerID, storeID, productID, ID)
    // and return it as one object .
    public class RecordModel
    {
       
        public Customer Customer { get; set; }
        public ProductSold ProductSold { get; set; }
        public Store Store { get; set; }
        public Product Product { get; set; }

    }
}