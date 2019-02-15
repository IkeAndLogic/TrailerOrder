using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrailerOrder.Models;

namespace TrailerOrder.ViewModels
{
    public class CompleteOrderViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
        public string OrderNumber { get; set; }

        
        public int TrailerId { get; set; }
        public Tractor Trailer { get; set; }
        public string TrailerNumber { get; set; }

        
        public CompleteOrderViewModel() { }


        public CompleteOrderViewModel(Employee employee, Order order, Trailer trailer)
        {
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            EmployeeId = employee.EmployeeID;

            OrderId = order.OrderID;

            OrderNumber = order.OrderNumber;

            TrailerId = trailer.TrailerID;
            TrailerNumber = trailer.TrailerNumber;

        }

    }
}
