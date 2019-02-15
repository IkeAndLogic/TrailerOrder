using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrailerOrder.ViewModels
{
    public class LoginViewModel
    {
        [Required,Display(Name= "User name")]
        public String UserName { get; set; }

        [Required, Display(Name = "Password")]
        public String Password { get; set; }

    }
}
