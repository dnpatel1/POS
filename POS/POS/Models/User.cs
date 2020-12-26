using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class User
    {
        [Key]
        [StringLength(50)]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Manager or Employee ?")]
        public bool IsAdmin { get; set; }

    }
}