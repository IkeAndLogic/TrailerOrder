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
            List<Employee> employees = context.Employees.ToList();
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
            Employee employeeDetails = context.Employees.SingleOrDefault(e => e.EmployeeID == id);
            System.Diagnostics.Debug.WriteLine(employeeDetails.EmployeeID);

            return employeeDetails;
        }


        public Employee Edit(Employee employeeToEdit)
        {
            //System.Diagnostics.Debug.WriteLine(employeeToEdit.EmployeeID);

            Employee employee = context.Employees.FirstOrDefault(e => e.EmployeeID == employeeToEdit.EmployeeID);



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
        }
    }