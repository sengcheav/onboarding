using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnBoardingFirst.Models
{
    public class Product
    {
      
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        [Required]
        [Range(0.01f, float.MaxValue)]
        public float Price { get; set; }
        public virtual ICollection<ProductSold> ProductSold { get; set; }

    }
}