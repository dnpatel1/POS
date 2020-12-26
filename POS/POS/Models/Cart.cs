using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Models
{
    
        public static class Cart
        {
            public static String UserName { get; set; }

            public static int temp_cart_id { get; set; }

            public static List<Product> Products = new List<Product>();

        }
    
}