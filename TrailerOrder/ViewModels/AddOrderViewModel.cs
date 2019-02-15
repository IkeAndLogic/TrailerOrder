using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TrailerOrder.Models;

namespace TrailerOrder.ViewModels
{
    public class AddOrderViewModel
    {
        [Required(ErrorMessage = "Must Provide Order Number")]
        [Display(Name = "Order Number")]
        public string OrderNumber { get; set; }

        [Required(ErrorMessage = "You must provide the Due Date"), DataType(DataType.Date)]
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }

        
        public int TrailerID { get; set; }

        //[Required(ErrorMessage = "Must Provide Trailer Number")]
        //[Display(Name = "Trailer Number")]
        public List<SelectListItem> TrailersForLoad { get; set; }

        
        public int CustomerID { get; set; }

        //[Required(ErrorMessage = "Must Provide Customer Name")]
        //[Display(Name = "Customer Number")]
        public List<SelectListItem> CustomersOrder { get; set; }






        public AddOrderViewModel()
        {
        }

        // this constructor takes two parameters for Trailer and Customer class to make it avaiable to the order form
        public AddOrderViewModel(IEnumerable<Trailer> trailersForLoad, IEnumerable<Customer> customersOrder)
        {

            TrailersForLoad = new List<SelectListItem>();

            foreach (var trailer in trailersForLoad)

            {
                TrailersForLoad.Add(new SelectListItem

                {
                    Value = (trailer.TrailerID).ToString(),
                    Text = trailer.TrailerNumber
                });
            };



            CustomersOrder = new List<SelectListItem>();

            foreach (var customer in customersOrder)

            {
                CustomersOrder.Add(new SelectListItem

                {
                    Value = (customer.CustomerID).ToString(),
                    Text = customer.CustomerName
                });
            };





        }

    }
}
