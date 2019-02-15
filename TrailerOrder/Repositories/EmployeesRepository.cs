using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrailerOrder.Data;
using TrailerOrder.Models;

namespace TrailerOrder.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {

        // a private TrailerOrderDbContext object that will be used within the class to interface with the database

        private readonly TrailerOrderDbContext context;


        public EmployeesRepository(TrailerOrderDbContext dbContext)
        {
            this.context = dbContext;
        }

        public EmployeesRepository() { }

        public Employee CreateEmployee(Employee newEmployee)
        {
            context.Employees.Add(newEmployee);
            context.SaveChanges();
            return newEmployee;
        }



        public List<Employee> GetAllEmployees()
        {
            //List<Employee> employees = context.Employees.ToList();


            List<Employee> employees = context.Employees.Include(o => o.Order).ToList();
            //List<Employee> employees = context.Employees.Include(o => o.Order).Include(t => t.Tractor).ToList();

            return employees;
        }


        public bool RemoveEmployee(int[] employeeIds)
        {
            foreach (int employeeId in employeeIds)
            {
                Employee removeEmployee = context.Employees.Single(c => c.EmployeeID == employeeId);
                // "removeEmployee !=null" checks to make sure item is found in the database and is not null. It is not necessary in this code
                // but it is good practice 
                if (removeEmployee != null && removeEmployee.WorkStatus == "Unavailable")
                {
                    context.Employees.Remove(removeEmployee);
                    context.SaveChanges();
                    return true;
                }

            }
            return false;
        }


        public Employee GetEmployeeWithId(int id)
        {
            //Employee employeeDetails = context.Employees.Include(t => t.Tractor).SingleOrDefault(e => e.EmployeeID == id);
            Employee employeeDetails = context.Employees.Where(e => e.EmployeeID == id).SingleOrDefault();

            return employeeDetails;
        }



        //this method will be moved to Order repo later
        public Order GetOrderWithId(int id)
        {
            Order getOrderWithId = context.Orders.FirstOrDefault(x => x.OrderID == id);
            return getOrderWithId;
        }



        // assign Tractor to Employee
        public Employee AssignTractor(int employeeId, int tractorId)
        {
            Employee employeeToAssignTractor = GetEmployeeWithId(employeeId);

            employeeToAssignTractor.TractorID = tractorId;
            context.SaveChanges();

            return employeeToAssignTractor;
        }

        //this method will be moved to Order repo later
        public IList<Order> GetAvailableOrders()
        {
            IList<Order> availableOrders = context.Orders.Where(x => x.OrderStatus == "Available").ToList();
            return availableOrders;
        }

        public Employee AssignOrder(int EmployeeId, int OrderId)
        {

            // driver object is matched with Employee id from the viewmodel
            Employee driverToBeAssigned = GetEmployeeWithId(EmployeeId);
            //Order object is matched with the order id from the viewmodel
            Order orderToBeAssigned = GetOrderWithId(OrderId);

            if (orderToBeAssigned != null)
            {
                driverToBeAssigned.WorkStatus = "Unavailable";

                driverToBeAssigned.OrderID = orderToBeAssigned.OrderID;

                orderToBeAssigned.OrderStatus = "Unavailable";
            }
            context.SaveChanges();

            return driverToBeAssigned;
        }



        public Employee UnassignOrder(int EmployeeId, int OrderId)
        {
            Employee driver = GetEmployeeWithId(EmployeeId);
            Order unassignOrder = GetOrderWithId(driver.OrderID);

            driver.WorkStatus = "Available";
            driver.OrderID = 0;
            unassignOrder.OrderStatus = "Available";

            context.SaveChanges();

            return driver;
        }


        public Employee Edit(Employee employeeToEdit)
        {
            Employee employee = GetEmployeeWithId(employeeToEdit.EmployeeID);


            employee.FirstName = employeeToEdit.FirstName;
            employee.MiddleName = employeeToEdit.MiddleName;
            employee.LastName = employeeToEdit.LastName;
            employee.StreetNumber = employeeToEdit.StreetNumber;
            employee.StreetName = employeeToEdit.StreetName;
            employee.City = employeeToEdit.City;
            employee.ZipCode = employeeToEdit.ZipCode;
            employee.SSN = employeeToEdit.SSN;
            employee.SsnConfirm = employeeToEdit.SsnConfirm;
            employee.Dob = employeeToEdit.Dob;
            employee.Title = employeeToEdit.Title;
            employee.LicNumber = employeeToEdit.LicNumber;
            employee.LicIssue = employeeToEdit.LicIssue;
            employee.LicExpire = employeeToEdit.LicExpire;
            employee.MedCardNumber = employeeToEdit.MedCardNumber;
            employee.MedIssue = employeeToEdit.MedIssue;
            employee.MedExpire = employeeToEdit.MedExpire;
            employee.UserName = employeeToEdit.UserName;
            employee.Password = employeeToEdit.Password;
            employee.PasswordConf = employeeToEdit.PasswordConf;

            context.SaveChanges();
            return employeeToEdit;
        }


        //////////////// All DriverTractorHistories will be moved to Driver ///////////////////

        //// this method will Add new driverTractorHistories
        //public DriverTractorAssignmentHistory AddHistory(int EmployeeID, int TractorID)
        //{
        //    Employee emp = GetEmployeeWithId(EmployeeID);
        //    Tractor trac = GetTractorWithId(TractorID);
        //    DriverTractorAssignmentHistory history = new DriverTractorAssignmentHistory(emp, trac);  
        //    context.DriverTractorsAssignmentHistory.Add(history);
        //    context.SaveChanges();
        //    return history;
        //}


        //// this method will get recent history driverTractorHistories
        //public DriverTractorAssignmentHistory getRecentHistoryNow(int employeeId, int tractorId, DateTime dateTime)
        //{
        //    DriverTractorAssignmentHistory history = context.DriverTractorsAssignmentHistory.Where(dt => dt.DateAssigned == null).Include(emp => emp.EmployeeId == employeeId).Include(trac => trac.TractorId == tractorId).Single();
        //    return history;
        //}

        //// this method will Add new driverTractorHistories
        //public DriverTractorAssignmentHistory CompleteHistory(DriverTractorAssignmentHistory updateHistory)
        //{
        //    DateTime dateTime = DateTime.Now;
        //    updateHistory.TimeUnassigned = dateTime.ToLongTimeString();
        //    updateHistory.DateUnassigned = dateTime.ToLongDateString();
        //    context.SaveChanges();
        //    return updateHistory;
        //}

        ////// this method will Remove new driverTractorHistories
        ////public bool DriverTractorAssignmentHistory RemoveHistory(int id)
        ////{
        ////    DriverTractorAssignmentHistory history = context.DriverTractorsAssignmentHistory.Where(dt => dt.DriverTractorId == id).Single();
        ////    if (history != null) { 
        ////    context.DriverTractorsAssignmentHistory.Remove(history);
        ////    context.SaveChanges(); }
        ////    //return false;
        ////}


        //// this method will return all driverTractorHistories
        //public IList<DriverTractorAssignmentHistory> DriverTractorHistory()
        //{
        //    IList<DriverTractorAssignmentHistory> DriverTractorHistories = context.DriverTractorsAssignmentHistory.ToList();
        //    return DriverTractorHistories;
        //}

        ////// this method will return driverTractorHistories for a particular Date
        ////// need to change the date to a date time object so you don't have to convert to string all the time
        ////public IList<DriverTractorAssignmentHistory> DriverTractorHistory(DateTime dateOfAssignment)
        ////{
        ////    string dateString = dateOfAssignment.ToLongDateString();
        ////    IList<DriverTractorAssignmentHistory> DriverTractorHistories = context.DriverTractorsAssignmentHistory.Where(dt => dt.DateAssigned == dateString).ToList();
        ////    return DriverTractorHistories;
        ////}

        //// this method will return driverTractorHistories for a particular Employee
        //public IList<DriverTractorAssignmentHistory> GetAllDriverToTractorHistory(int employeeId)
        //{
        //    IList<DriverTractorAssignmentHistory> DriverTractorHistories = context.DriverTractorsAssignmentHistory.Where(dt => dt.EmployeeId == employeeId).ToList();
        //    return DriverTractorHistories;
        //}


        //// this method will return driverTractorHistories for a particular Tractor
        //public IList<DriverTractorAssignmentHistory> GetAllTractortoDriverHistory(int tractorId)
        //{
        //    IList<DriverTractorAssignmentHistory> DriverTractorHistories = context.DriverTractorsAssignmentHistory.Where(dt => dt.TractorId == tractorId).ToList();
        //    return DriverTractorHistories;
        //}


        //this method will be moved to Tractor repo later
        public Employee UnassignTractor(int employeeId)
        {
            Employee employeeToUnassignTruck = GetEmployeeWithId(employeeId);
            employeeToUnassignTruck.TractorID = null;
            context.SaveChanges();

            return employeeToUnassignTruck;
        }


















    }
}