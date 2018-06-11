using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrailerOrder.Models
{
    public class Customer
    {

        public string CustomerName { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public int CustomerID { get; set; }

        // A List interface type property to house the entier list of Orders of a given class
        public IList<Order> CustomerOrders { get; set; }
    }
}
