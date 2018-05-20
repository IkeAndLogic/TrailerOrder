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
        public virtual Trailer TrailerForLoad { get; set; }

        public Order()
        {
            OrderStatus = "Available";
        }

    }
}
