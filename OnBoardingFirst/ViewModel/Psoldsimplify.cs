using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnBoardingFirst.ViewModel
{
    public class Psoldsimplify
    {

      


        public string CustomerName { get; set; }
        public int CustomerID { get; set; }
        
        public int StoreID { get; set; }
        public string StoreName { get; set; }

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }

        public int ProductSoldID { get; set; }
        public DateTime? ProductSoldDate { get; set; }


    }
}