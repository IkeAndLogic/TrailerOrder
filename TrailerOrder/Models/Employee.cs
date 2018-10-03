using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrailerOrder.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }

        //
        public string WorkStatus{get;set;}
        public bool LoginStatus { get; set; }



        //Many Orders to one employee
        public List<Order> Order { get; set; }

        public Employee() {

            WorkStatus = "Unavailable";
            LoginStatus = false;
        }
    }
}
