using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Transaction Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter total amount")]
        [Display(Name = "Total Amount")]
        public double Amount_Total { get; set; }

        [Required(ErrorMessage = "Please enter method of payment")]
        [Display(Name = "Method of Payment")]
        [Range(1, 3)]
        //1- For Credit, 2- For Debit ,3- For Cash
        public int Method_Of_Payment { get; set; }

        [Required(ErrorMessage = "Please enter a valid date")]
        [Display(Name = "Date of the transaction")]
        public DateTime Date { get; set; }

        public int cart_id { get; set; }

        public ICollection<TransProd> TransProd { get; set; }

        //public List<Product> Products { get; set; }
        public ICollection<Product> products { get; set; }


    }
}