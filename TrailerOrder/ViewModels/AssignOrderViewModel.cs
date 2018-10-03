using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrailerOrder.Models;

namespace TrailerOrder.ViewModels
{
    public class AssignOrderViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int EmployeeID {get;set;}
        public int TrailerID { get; set; }

        public int OrderID { get; set; }

        public List<SelectListItem> Orders { get; set; }

        public string OrderNumber { get; set; }
        public string OrderStatus { get; set; }


        public AssignOrderViewModel()
        {
        }



        public AssignOrderViewModel(Employee driver, IEnumerable<Order> orders)
        {

            FirstName = driver.FirstName;
            LastName = driver.LastName;
            EmployeeID = driver.EmployeeID;

            Orders = new List<SelectListItem>();

            foreach (var order in orders)

            {
                Orders.Add(new SelectListItem

                {
                    Value = (order.OrderID).ToString(),
                    Text = order.OrderNumber
                });
            };





        }
    }
}
