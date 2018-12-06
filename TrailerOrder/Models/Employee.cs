using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrailerOrder.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        // property for first name
        public string FirstName { get; set; }

        // property for middle name
        public string MiddleName { get; set; }

        // property for Last name
        public string LastName { get; set; }

        //property for Street Number of Employee Address
        public string StreetNumber { get; set; }

        //property for Street Name of Employee Address
        public string StreetName { get; set; }

        //property for city of Employee Address
        public string City { get; set; }

        //property for ZipCode of Employee Address
        public string ZipCode { get; set; }
    
        // property for social security number
        public string SSN { get; set; }

        // property for social security number confirmation
        public string SsnConfirm { get; set; }

        // property for date of birth
        public DateTime Dob { get; set; }

        // for title of the employee
        public EmployeeType Title { get; set; }

        //property for license number
        public string LicNumber { get; set; }

        //property for license issuance
        public DateTime LicIssue { get; set; }

        //property for license expiration date
        public DateTime LicExpire { get; set; }

        //property for DOT Medical Card Number
        public string MedCardNumber { get; set; }

        //property for DOT Medical Card issance date
        public DateTime MedIssue { get; set; }

        //property for DOT Medical Card expiration date
        public DateTime MedExpire { get; set; }

        //property for user name
        public string UserName { get; set; }

        //property for password
        public string Password { get; set; }

        //property for password confrimation
        public string PasswordConf { get; set; }




        // boolean to determine if there is any compliant
        public bool DotCompliant { get; set; }

        //// might need deletion if not used at the end
        //// boolean to determine if employee went over their dot compliant clock time
        //public bool ClockStatus { get; set; }

        //boolean to determine if employee is available for work
        public string WorkStatus{get;set;}

        //boolean to determine if employee is available for work
        public bool LoginStatus { get; set; }



        //property to represent Many Orders to one employee
        public List<Order> Order { get; set; }



        public Employee() {

            WorkStatus = "Unavailable";
            LoginStatus = false;
            DotCompliant = false;
        }
    }
}
