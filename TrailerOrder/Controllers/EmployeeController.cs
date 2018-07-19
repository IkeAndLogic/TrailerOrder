using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrailerOrder.Data;
using TrailerOrder.Models;
using TrailerOrder.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrailerOrder.Controllers
{
    public class EmployeeController : Controller
    {



        // a private TrailerOrderDbContext object that will be used within the class to interface with the database

        private readonly TrailerOrderDbContext context;

        // create a constructor that takes the TrailerDbContext object as a parameter
        // so that you can have access to the class in the framework(from the "startup.cs" file)

        public EmployeeController(TrailerOrderDbContext dbContext)
        {
            this.context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Employee> employees = context.Employees.ToList();
            return View(employees);
        }


        //Add
        public IActionResult Add()
        {

            //Employee list will populate all Employee object is necessary to access the Employee Data
            //List<Employee> employees = context.Employees.ToList();
            AddEmployeeViewModel addEmployeeViewModel = new AddEmployeeViewModel();
            return View(addEmployeeViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddEmployeeViewModel addEmployeeViewModel)
        {

            if (ModelState.IsValid)
            {
                Employee newEmployee = new Employee
                {
                    FirstName = addEmployeeViewModel.FirstName,
                    LastName = addEmployeeViewModel.LastName,
                    DOB = addEmployeeViewModel.DOB
                };

                context.Employees.Add(newEmployee);
                context.SaveChanges();
                return Redirect("/");
            };
                return View(addEmployeeViewModel);
        }






        //Remove
        public IActionResult Remove()
        {
            RemoveEmployeeViewModel removeEmployeeViewModel = new RemoveEmployeeViewModel(context.Employees.ToList());
            return View(removeEmployeeViewModel);
        }


        [HttpPost]
        public IActionResult Remove(RemoveEmployeeViewModel removeEmployeeViewModel)
        {
            return View();
        }


        public IActionResult EmployeeInfo()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }


        public IActionResult AssignOrder(int id)
        {

            Employee driverToAssignOrder = context.Employees.FirstOrDefault(x => x.EmployeeID == id);

            IList<Order> availableOrders = context.Orders.Where(x => x.OrderStatus == "Available").ToList();

            AssignOrderViewModel assignOrderViewModel = new AssignOrderViewModel(driverToAssignOrder, availableOrders);

            return View(assignOrderViewModel);
        }


        [HttpPost]
        public IActionResult AssignOrder(AssignOrderViewModel assignOrderViewModel)
        {

            Employee driver = context.Employees.FirstOrDefault(o => o.EmployeeID == assignOrderViewModel.EmployeeID);
            //Trailer newTrailer = context.Trailers.FirstOrDefault(t => t.TrailerID == assignOrderViewModel.TrailerID);

            //driver.OrderNumber = assignOrderViewModel.OrderNumber;




            Order orderToBeAssigned = context.Orders.FirstOrDefault(t => t.OrderNumber == assignOrderViewModel.OrderNumber);

            if (orderToBeAssigned != null)
            {
                driver.OrderID = orderToBeAssigned.OrderID;
                orderToBeAssigned.OrderStatus = "Unavailable";

            }


            //orderToBeAssigned.OrderStatus = "Unavailable";
              context.SaveChanges();

            return Redirect("/Employee");
        }

    }
}
