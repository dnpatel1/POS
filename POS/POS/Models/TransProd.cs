using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class TransProd
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "TransProd Id")]
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        //Navigation Property
        public Product Product { get; set; }

        [ForeignKey("Transaction")]
        public int TransactionId { get; set; }
        //Navigation Property
        public Transaction Transaction { get; set; }

        [Required(ErrorMessage = "Product quantity should be atleast 1")]
        public int ProductQuantity { get; set; }

    }
}