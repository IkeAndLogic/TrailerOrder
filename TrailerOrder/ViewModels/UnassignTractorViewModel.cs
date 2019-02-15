using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrailerOrder.Models;

namespace TrailerOrder.ViewModels
{
    public class UnassignTractorViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmployeeID { get; set; }

        public int? TractorID { get; set; }
        public string TractorNumber { get; set; }
        public string TractorStatus { get; set; }
        public string EmployeeStatus { get; set; }

        public UnassignTractorViewModel() { }

        public UnassignTractorViewModel(Employee emp, Tractor trac)
        {
            FirstName = emp.FirstName;
            LastName = emp.LastName;
            EmployeeID = emp.EmployeeID;
       
            EmployeeStatus = emp.WorkStatus;

            TractorNumber = trac.TruckNumber;
            TractorStatus = trac.Status;
            TractorID = trac.TractorID;
        }

    }
}
