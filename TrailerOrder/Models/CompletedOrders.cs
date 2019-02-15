//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace TrailerOrder.Models
//{
//    public class CompletedOrders
//    {
//        public string FirstName { get; set; }
//        public string MiddleName { get; set; }
//        public string LastName { get; set; }

//        public int EmployeeId { get; set; }
//        //DeliveryDriver is probably a better property name. Consider Changing it in tne class and dbcontext,and reruning migriation
//        public Employee Employees { get; set; }

//        public int OrderId { get; set; }
//        public Order OrdersCompleted { get; set; }

//        public string TractorNumber {get;set;}
//        public string TrailerNumber { get; set; }
//        public string OrderNumber  {get; set; }
//        public string OrderStatus { get; set; }
//        public string CustomerName  {get; set; }

//        public string DateCompleted { get; set; }
//        public string TimeCompleted { get; set; }

//        //public int TrailerId {get; set;}
//        //public virtual List<Trailer> Trailers {get; set;}

//        //public int CustomerId { get; set; }
//        //public virtual List<Customer> Customers {get; set;}

//        public CompletedOrders()
//        {

//        }

//        public CompletedOrders(Employee employee, Order order,Tractor tractor,Trailer trailer,Customer customer)
//        {
//            FirstName = employee.FirstName;
//            MiddleName = employee.MiddleName;
//            LastName = employee.LastName;
//            EmployeeId = employee.EmployeeID;

//            OrderId = employee.OrderID;
//            OrderNumber = order.OrderNumber;
//            OrderStatus = order.OrderStatus;
//            TrailerNumber = trailer.TrailerNumber;

//            TractorNumber = tractor.TruckNumber;

            

//        }

//    }
//}
