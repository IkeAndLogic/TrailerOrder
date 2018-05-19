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
        public string TrailerStatus { get; set; }

        public int TrailerID { get; set; }

        //has a one to one relationship with order
        public virtual Order orderforTrailer { get; set; }


        public Trailer()
        {
            TrailerStatus = "Avaliable";
        }


    }
}
