using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrailerOrder.Models
{
    public class Tractor
    {
        public int TractorID { get; set; }

        public string TruckNumber {get; set;}
        public string TractorMake { get; set; }
        public string TractorModel { get; set; }
        public string Year { get; set; }

        public string VinNumber { get; set; }
        public string PlateNumber { get; set; }
        public DateTime DotInp { get; set; }
        public DateTime RegDate { get; set; }

        public string Status { get; set; }

        
        public DateTime DateAssigned { get; set; }
        public DateTime DateReturned { get; set; }

        //Tractor and Employee are going to have a one to one relationship. 
        //below is a navigational property fo Employee Table


        
        public virtual Employee Employee { get; set; }
        



        //public int? EmployeeID { get; set; }

        ////Tractor Has many Completed Orders
        //public virtual List<CompletedOrders> CompletedOrders { get; set; }

        //Tractor Has many DriverTractorAssignmentHistories
        public virtual List<DriverTractorAssignmentHistory> DriverTractorAssignmentHistories { get; set; }

        public Tractor()
        {
            Status = "Available";
        }

    }
}
