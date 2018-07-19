using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrailerOrder.Models;

namespace TrailerOrder.ViewModels
{
    public class EditOrderViewModel
    {

        //[Required(ErrorMessage = "Must Provide Order Number")]
        public string OrderNumber { get; set; }
        public int OrderID { get; set; }

        public int CustomerOrdersID { get; set; }

        public int TrailerForLoadID { get; set; }

       // public Order Order { get; set; }

        //public int TrailerForLoadID { get; set; }
        public List<SelectListItem> TrailersForLoad { get; set; }

        //public int CustomerOrdersID { get; set; }
        public List<SelectListItem> CustomersOrder { get; set; }





        public EditOrderViewModel()
        {
        }




        // this constructor takes two parameters for Trailer and Customer class to make it avaiable to the order form
        public EditOrderViewModel(Order orderToEdit, IEnumerable<Trailer> trailersForLoad, IEnumerable<Customer> customersOrder)
        {
            OrderNumber = orderToEdit.OrderNumber;
            CustomerOrdersID = orderToEdit.CustomerOrdersID;
            OrderID = orderToEdit.OrderID;
            TrailerForLoadID = orderToEdit.TrailerForLoadID;


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
