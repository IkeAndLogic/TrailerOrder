using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrailerOrder.Models
{
    public class DriverTractorAssignmentHistory
    {
        
        public int EmployeeId { get; set; }
        public Employee Driver { get; set; }

        public int TractorId { get; set; }
        public Tractor Tractor { get; set; }

        public string TractorNumber { get; set; }

        public DateTime DateTimeAssigned { get; set; }
        public DateTime? DateTimeUnassigned { get; set; }

        public DriverTractorAssignmentHistory()
        {
        }

        public DriverTractorAssignmentHistory(Employee driver, Tractor tractor)
        {
            TractorNumber = tractor.TruckNumber;
            EmployeeId = driver.EmployeeID;
            TractorId = tractor.TractorID;
            DateTimeAssigned = DateTime.Now;
            DateTimeUnassigned = null;
        }

    }
}
