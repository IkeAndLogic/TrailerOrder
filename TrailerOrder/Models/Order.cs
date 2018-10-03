using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrailerOrder.Models
{
    public class Order
    {
        public string OrderNumber { get; set; }
        public string OrderStatus { get; set; }

        public int OrderID { get; set; }



        //has a one to one relationship with Trailer
        public int TrailerForLoadID { get; set; }
        public virtual Trailer TrailerForLoad { get; set; }

       
        // foreign key will allow us reference the specific customer a particular order belongs to within the
        //database. Because of the one to many relationship we need to be able to store the foreign key as an identifier
        // in the "Order" table to identify the customer a particular order belongs to
        public int CustomerOrdersID { get; set;}
        // navigational property for  the "Customer" Class
        public virtual Customer CustomerOrders { get; set; }

        // Order has a one to many relationship to Employee
        public int? EmployeeID { get; set; }
        public  Employee Driver { get; set; }


        public DateTime DueDate { get; set; }
        public DateTime DateDelivered { get; set; }
        public DateTime DateAssigned { get; set; }

        public bool Completed { get; set; }

        public Order()
        {
            OrderStatus = "Available";
            
            Completed = false;

        }

    }
}
