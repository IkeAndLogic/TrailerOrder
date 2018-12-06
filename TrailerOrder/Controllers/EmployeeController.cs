using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrailerOrder.Data;
using TrailerOrder.Models;
using TrailerOrder.Repositories;
using TrailerOrder.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrailerOrder.Controllers
{
    public class EmployeeController : Controller
    {



        // a private TrailerOrderDbContext object that will be used within the class to interface with the database

        //private readonly TrailerOrderDbContext context;

        // create a constructor that takes the TrailerDbContext object as a parameter
        // so that you can have access to the class in the framework(from the "startup.cs" file)

        //public EmployeeController(TrailerOrderDbContext dbContext)
        //{
        //    this.context = dbContext;
        //}


        private IEmployeesRepository repo;

        public EmployeeController(IEmployeesRepository repo)
        {
            this.repo = repo;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            //List<Employee> employees = context.Employees.ToList();
            //return View(employees);

            return View(repo.GetAllEmployees());
        }


        //Add
        public IActionResult Add()
        {
            AddEmployeeViewModel addEmployeeViewModel = new AddEmployeeViewModel();
            return View(addEmployeeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(AddEmployeeViewModel addEmployeeViewModel)
        {

            if (ModelState.IsValid)
            {
                Employee newEmployee = new Employee
                {
                    FirstName = addEmployeeViewModel.FirstName,
                    MiddleName = addEmployeeViewModel.MiddleName,
                    LastName = addEmployeeViewModel.LastName,
                    StreetNumber = addEmployeeViewModel.StreetNumber,
                    StreetName = addEmployeeViewModel.StreetName,
                    City = addEmployeeViewModel.City,
                    ZipCode = addEmployeeViewModel.ZipCode,
                    SSN = addEmployeeViewModel.SSN,
                    SsnConfirm = addEmployeeViewModel.SsnConfirm,
                    Dob = addEmployeeViewModel.Dob.Date,
                    Title = addEmployeeViewModel.Title,

                    LicNumber = addEmployeeViewModel.LicNumber,
                    LicIssue = addEmployeeViewModel.LicIssue.Date,
                    LicExpire = addEmployeeViewModel.LicExpire.Date,
                    MedCardNumber = addEmployeeViewModel.MedCardNumber,
                    MedIssue = addEmployeeViewModel.MedIssue.Date,
                    MedExpire = addEmployeeViewModel.MedExpire.Date,
                    UserName = addEmployeeViewModel.UserName,
                    Password = addEmployeeViewModel.Password,
                    PasswordConf = addEmployeeViewModel.PasswordConf
                };

                //context.Employees.Add(newEmployee);
                //context.SaveChanges();

                repo.CreateEmployee(newEmployee);

                return Redirect("/");
            };
            return View(addEmployeeViewModel);
        }


        //Remove
        public IActionResult Remove()
        {
            RemoveEmployeeViewModel removeEmployeeViewModel = new RemoveEmployeeViewModel(repo.GetAllEmployees());
            return View(removeEmployeeViewModel);
        }


        [HttpPost]
        public IActionResult Remove(int[] employeeIds)
        {
            // we are doing two things here; calling the function, and also checking if it returns false
            if (repo.RemoveEmployee(employeeIds) == false)
            {
                return Redirect("/Employee/Remove");
            }
            else
            {
                return Redirect("/Employee");
            }
            //    foreach (int employeeId in employeeIds)
            //    {

            //        Employee removeEmployee = context.Employee.Single(c => c.EmployeeID == employeeId);



            //        if (removeEmployee.WorkStatus == "Available")
            //        {

            //            context.Employee.Remove(removeEmployee);

            //            // need to display an error message on the remove form
            //        }

            //        else
            //        {
            //            return Redirect("/Employee/Remove");

            //        }

            //    }

            //    context.SaveChanges();
            //    return Redirect("/");
        }


        public IActionResult EmployeeDetails(int id)
        {

            return View(repo.GetEmployeeWithId(id));
        }

        public IActionResult Edit(int id)
        {
            EditEmployeeViewModel editEmployeeViewModel = new EditEmployeeViewModel(repo.GetEmployeeWithId(id));

            return View(editEmployeeViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditEmployeeViewModel editEmployeeViewModel)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee
                {
                    FirstName = editEmployeeViewModel.FirstName,
                    MiddleName = editEmployeeViewModel.MiddleName,
                    LastName = editEmployeeViewModel.LastName,
                    StreetNumber = editEmployeeViewModel.StreetNumber,
                    StreetName = editEmployeeViewModel.StreetName,
                    City = editEmployeeViewModel.City,
                    ZipCode = editEmployeeViewModel.ZipCode,
                    SSN = editEmployeeViewModel.SSN,
                    SsnConfirm = editEmployeeViewModel.SsnConfirm,
                    Dob = editEmployeeViewModel.Dob,
                    Title = editEmployeeViewModel.Title,
                    LicNumber = editEmployeeViewModel.LicNumber,
                    LicIssue = editEmployeeViewModel.LicIssue,
                    LicExpire = editEmployeeViewModel.LicExpire,
                    MedCardNumber = editEmployeeViewModel.MedCardNumber,
                    MedIssue = editEmployeeViewModel.MedIssue,
                    MedExpire = editEmployeeViewModel.MedExpire,
                    UserName = editEmployeeViewModel.UserName,
                    Password = editEmployeeViewModel.Password,
                    PasswordConf = editEmployeeViewModel.PasswordConf,
                };

                repo.Edit(employee);
                return Redirect("/Employee");
            }
                return View(editEmployeeViewModel);
            }

        
        


    }
}
