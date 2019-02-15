using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrailerOrder.Models
{
    public class Trailer
    {
        public string SerialNumber { get; set; }
        public string TrailerNumber { get; set; }
        public string TrailerMake { get; set; }
        public string TrailerModel { get; set; }
        public string Year { get; set; }
        public DateTime RegDate { get; set; }
        public DateTime InspDate { get; set; }
        public string TrailerStatus { get; set; }

        public int TrailerID { get; set; }

        //has a one to Many relationship with order
        public virtual List<Order> OrderforTrailer { get; set; }


        public Trailer()
        {
            TrailerStatus = "Available";
        }


    }
}
