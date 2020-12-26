using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "Product name is required")]
        [Display(Name = "Product Name")]
        public string product_name { get; set; }

        [Required(ErrorMessage = "Product price is required")]
        [Display(Name = "Price")]
        public double product_price { get; set; }
        [Display(Name = "Stock Remaining")]
        public int stock_remaining { get; set; }
        [Display(Name = "Stock Flag")]
        public int stock_flag { get; set; }
        [Display(Name = "Maximum Stock Capacity")]
        public int stock_max { get; set; }

        public ICollection<TransProd> TransProd { get; set; }

    }
}