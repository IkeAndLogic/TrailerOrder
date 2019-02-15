using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrailerOrder.ViewModels
{
    public class EditCustomerViewModel
    {

        [Required(ErrorMessage = "You must provide the Customer Name"), MinLength(1), MaxLength(50)]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }


        [Required(ErrorMessage = "You must provide the Street Number"), MinLength(1), MaxLength(50)]
        [Display(Name = "Street Number")]
        public string StreetNumber { get; set; }

        [Required(ErrorMessage = "You must provide the Street Name"), MinLength(1), MaxLength(50)]
        [Display(Name = "Street Name")]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "You must provide the Zip Code"), MinLength(1), MaxLength(50)]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "You must provide the City"), MinLength(1), MaxLength(50)]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "You must provide the State"), MinLength(1), MaxLength(50)]
        [Display(Name = "State")]
        public string State { get; set; }

        public int CustomerID
        {
            get; set;

        }
    }
}