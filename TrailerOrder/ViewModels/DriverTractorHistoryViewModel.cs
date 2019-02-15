using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrailerOrder.Models;

namespace TrailerOrder.ViewModels
{
    public class DriverTractorHistoryViewModel
    {

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        //public string DateAssigned { get; set; }
        //public string TimeAssigned { get; set; }

        //public string DateUnassigned { get; set; }
        //public string TimeUnassigned { get; set; }

        public string TractorNumber { get; set; }

        public int EmployeeId { get; set; }
        public int TractorId { get; set; }


        public DriverTractorHistoryViewModel(Employee driver, Tractor tractor,DriverTractorAssignmentHistory driverTractorAssignmentHistory)
        {
            FirstName = driver.FirstName;
            MiddleName = driver.MiddleName;
            LastName = driver.LastName;

            EmployeeId = driver.EmployeeID;
            TractorId = tractor.TractorID;

            TractorNumber = tractor.TruckNumber;
            
        }



        //public DriverTractorHistoryViewModel(DriverTractorAssignmentHistory driverTractorAssignmentHistory)
        //{
        //    FirstName = driverTractorAssignmentHistory.Driver.FirstName;
        //    MiddleName = driverTractorAssignmentHistory.Driver.MiddleName;
        //    LastName = driverTractorAssignmentHistory.Driver.LastName;

        //    EmployeeId = driverTractorAssignmentHistory.Driver.EmployeeID;
        //    TractorId = driverTractorAssignmentHistory.Driver.TractorID.GetValueOrDefault();

        //    TractorNumber = driverTractorAssignmentHistory.Tractor.TruckNumber;

        //    TimeAssigned = driverTractorAssignmentHistory.TimeAssigned;
        //    DateAssigned = driverTractorAssignmentHistory.DateAssigned;
        //}

        public DriverTractorHistoryViewModel()
        { }



        }
}
