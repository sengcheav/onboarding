using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnBoardingFirst.Models
{
    public class Store
    {
        
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Store Name")]
        public string Name { get; set; }
        
        public string Address { get; set; }

        public virtual ICollection<ProductSold> ProdutSold { get; set; }
    }
}