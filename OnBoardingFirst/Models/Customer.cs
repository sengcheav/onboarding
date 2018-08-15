using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnBoardingFirst.Models
{
    public class Customer
    {

        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }

        public string Address { get; set; }

        public virtual ICollection<ProductSold> ProductSold { get; set; }
    }
}