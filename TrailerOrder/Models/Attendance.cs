using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrailerOrder.Models
{
    public class Attendance
    {
        public int AttendanceID { get; set; }

        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }


        public DateTime WorkDay { get; set; }
        public string FirstName{get;set;}
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        //// property to represent Many Employee to one Attendance relationship
        //public int EmployeeID { get; set; }
        //public Employee Employee { get; set; }

        ////property to represent Many Tractor to one employee
        //public int TractorID { get; set; }
        //public Tractor Tractor { get; set; }


        public Attendance(){ }

        public Attendance(DateTime workDay)
        {
            WorkDay = workDay.Date;
            //Employee = null;
            //Tractor = null;
        }


    }
}
