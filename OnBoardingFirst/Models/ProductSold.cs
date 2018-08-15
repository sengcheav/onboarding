using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnBoardingFirst.Models
{
    public class ProductSold
    {
        
        [Key]
        public int ID { get; set; }

        [Required]
        [ForeignKey("Product")]
        public int ProductID { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }

        [Required]
        [ForeignKey("Store")]
        public int StoreID { get; set; }

        [Required]
        public DateTime? DateSold { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
        public virtual Store Store{ get; set; }
    }
}