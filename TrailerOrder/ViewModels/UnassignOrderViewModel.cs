using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrailerOrder.Models;

namespace TrailerOrder.ViewModels
{
    public class UnassignOrderViewModel
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmployeeID { get; set; }

        public int OrderID { get; set; }
        public string OrderNumber { get; set; }
        public string OrderStatus { get; set; }


        public UnassignOrderViewModel() { }

        public UnassignOrderViewModel(Employee emp, Order ord) {

            FirstName = emp.FirstName;
            LastName = emp.LastName;
            EmployeeID = emp.EmployeeID;

            OrderNumber = ord.OrderNumber;
            OrderStatus = ord.OrderStatus;
            OrderID = ord.OrderID;

        }

    }
}
