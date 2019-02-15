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


        private IEmployeesRepository empRepo;
        private ITractorRepository truRepo;
        private IDriverTractorHistoryRepository dtRepo;

        public EmployeeController(IEmployeesRepository empRepo, ITractorRepository truRepo, IDriverTractorHistoryRepository dtRepo)
        {
            this.empRepo = empRepo;
            this.truRepo = truRepo;
            this.dtRepo = dtRepo;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            //List<Employee> employees = context.Employees.ToList();
            //return View(employees);

            return View(empRepo.GetAllEmployees());
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
                    PasswordConf = addEmployeeViewModel.PasswordConf,
                    //TractorID = 0
                };

                //context.Employees.Add(newEmployee);
                //context.SaveChanges();

                empRepo.CreateEmployee(newEmployee);

                return Redirect("/Employee");
            };
            return View(addEmployeeViewModel);
        }


        //Remove
        public IActionResult Remove()
        {
            RemoveEmployeeViewModel removeEmployeeViewModel = new RemoveEmployeeViewModel(empRepo.GetAllEmployees());
            return View(removeEmployeeViewModel);
        }


        [HttpPost]
        public IActionResult Remove(int[] employeeIds)
        {
            // we are doing two things here; calling the function, and also checking if it returns false
            if (empRepo.RemoveEmployee(employeeIds) == false)
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

            return View(empRepo.GetEmployeeWithId(id));

        }

        public IActionResult Edit(int id)
        {
            // remember since repo.GetEmployee is returning an Employee object and the Employee default constructor is returning
            //a null for the EmployeeID Field, we have  create a new object and explicitly assign the EmployeeID values to it

            Employee repoEmployeeObject = empRepo.GetEmployeeWithId(id);

            Employee employee = new Employee()
            {

                EmployeeID = repoEmployeeObject.EmployeeID,


                FirstName = repoEmployeeObject.FirstName,
                MiddleName = repoEmployeeObject.MiddleName,
                LastName = repoEmployeeObject.LastName,
                StreetNumber = repoEmployeeObject.StreetNumber,
                StreetName = repoEmployeeObject.StreetName,
                City = repoEmployeeObject.City,
                ZipCode = repoEmployeeObject.ZipCode,
                SSN = repoEmployeeObject.SSN,
                SsnConfirm = repoEmployeeObject.SsnConfirm,
                Dob = repoEmployeeObject.Dob,
                Title = repoEmployeeObject.Title,
                LicNumber = repoEmployeeObject.LicNumber,
                LicIssue = repoEmployeeObject.LicIssue,
                LicExpire = repoEmployeeObject.LicExpire,
                MedCardNumber = repoEmployeeObject.MedCardNumber,
                MedIssue = repoEmployeeObject.MedIssue,
                MedExpire = repoEmployeeObject.MedExpire,
                UserName = repoEmployeeObject.UserName,
                Password = repoEmployeeObject.Password,
                PasswordConf = repoEmployeeObject.PasswordConf
            };

            EditEmployeeViewModel editEmployeeViewModel = new EditEmployeeViewModel(employee);

            return View(editEmployeeViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditEmployeeViewModel editEmployeeViewModel)
        {
            if (ModelState.IsValid)
            {
                Employee employeeToEdit = new Employee
                {
                    EmployeeID = editEmployeeViewModel.EmployeeID,

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

                    //Order = null,
                    //WorkStatus = "Unavailable",
                    //LoginStatus = false,
                    //DotCompliant = false,

                };

                empRepo.Edit(employeeToEdit);
                return Redirect("/Employee");
            }
            return View(editEmployeeViewModel);
        }






        public IActionResult AssignTractor(int id)
        {
            Employee driverToAssignTractor = empRepo.GetEmployeeWithId(id);

            //Make sure this method is being drawn from the Tractor Repo and no the Employee Repo
            List<Tractor> availableTractors = truRepo.GetAvailableTractor();

            AssignTractorViewModel assignTractorViewModel = new AssignTractorViewModel(driverToAssignTractor, availableTractors);

            return View(assignTractorViewModel);
        }

        [HttpPost]
        public IActionResult AssignTractor(AssignTractorViewModel assignTractorViewModel)
        {
            if (ModelState.IsValid)
            {
                //Employee employee = new Employee()
                //{
                //    EmployeeID = assignTractorViewModel.EmployeeID,
                //    TractorID = assignTractorViewModel.TractorID
                //};


                Employee driver = empRepo.GetEmployeeWithId(assignTractorViewModel.EmployeeID);
                Tractor truck = truRepo.GetTractorWithId(assignTractorViewModel.TractorID);

                //this is where you need to update DriverTractorAssignmentHistory or do it in the repo.AssignTractor for abstraction purposes
                empRepo.AssignTractor(driver.EmployeeID, truck.TractorID);

                // changes the availability of tractor once assigned
                truRepo.ChangeStatusWithId(driver.TractorID.GetValueOrDefault());

                //adds it to drivertractor history
                dtRepo.AddHistory(driver, truck);

                return Redirect("/Employee");
            };
            return View(assignTractorViewModel);
        }







        public IActionResult UnassignTractor(int id)
        {

            Employee driverToUnassignTractor = empRepo.GetEmployeeWithId(id);
            Tractor tractorToBeUnassigned = truRepo.GetTractorWithId(driverToUnassignTractor.TractorID.GetValueOrDefault());

            UnassignTractorViewModel unassignTractorViewModel = new UnassignTractorViewModel(driverToUnassignTractor, tractorToBeUnassigned);
            return View(unassignTractorViewModel);
        }



        [HttpPost]
        public IActionResult UnassignTractor(UnassignTractorViewModel unassignTractorViewModel)
        {
            if (ModelState.IsValid)
            {
                Employee driver = empRepo.GetEmployeeWithId(unassignTractorViewModel.EmployeeID);
                Tractor truck = truRepo.GetTractorWithId(unassignTractorViewModel.TractorID.GetValueOrDefault());
                
                empRepo.UnassignTractor(driver.EmployeeID);
                truRepo.ChangeStatusWithId(truck.TractorID);
                dtRepo.RemoveHistory(driver, truck);
                return Redirect("/Employee");

            };

            return View(unassignTractorViewModel);
        }






        public IActionResult CompleteAssignment(int id)
        {

            Employee driverToUnassignTractor = empRepo.GetEmployeeWithId(id);
            Tractor tractorToBeUnassigned = truRepo.GetTractorWithId(driverToUnassignTractor.TractorID.GetValueOrDefault());

            UnassignTractorViewModel unassignTractorViewModel = new UnassignTractorViewModel(driverToUnassignTractor, tractorToBeUnassigned);
            return View(unassignTractorViewModel);
        }

        [HttpPost]
        public IActionResult CompleteAssignment(UnassignTractorViewModel unassignTractorViewModel)
        {
            if (ModelState.IsValid)
            {
                Employee driver = empRepo.GetEmployeeWithId(unassignTractorViewModel.EmployeeID);
                Tractor truck = truRepo.GetTractorWithId(unassignTractorViewModel.TractorID.GetValueOrDefault());

                empRepo.UnassignTractor(driver.EmployeeID);
                truRepo.ChangeStatusWithId(truck.TractorID);
                dtRepo.CompleteHistory(driver, truck);
                return Redirect("/Employee");

            };

            return View(unassignTractorViewModel);
        }

        public IActionResult AssignOrder(int id)
        {
            Employee driverToAssignOrder = empRepo.GetEmployeeWithId(id);
            IList<Order> availableOrders = empRepo.GetAvailableOrders();
            
            AssignOrderViewModel assignOrderViewModel = new AssignOrderViewModel(driverToAssignOrder, availableOrders);
            return View(assignOrderViewModel);
        }


        [HttpPost]
        public IActionResult AssignOrder(AssignOrderViewModel assignOrderViewModel)
        {

            if (ModelState.IsValid)
            {
                empRepo.AssignOrder(assignOrderViewModel.EmployeeID.GetValueOrDefault(), assignOrderViewModel.OrderID.GetValueOrDefault());
            }
       
            return Redirect("/Employee");
        }




        public IActionResult UnassignOrder(int id)
        {
           
            Employee driver = empRepo.GetEmployeeWithId(id);

            Order UnassignOrder = empRepo.GetOrderWithId(driver.OrderID);

            UnassignOrderViewModel unassignOrderViewModel = new UnassignOrderViewModel(driver, UnassignOrder);

            return View(unassignOrderViewModel);
        }



        [HttpPost]
        //[ActionName("Edit")]
        public IActionResult UnassignOrder(UnassignOrderViewModel unassignOrderViewModel)
        {

            if (ModelState.IsValid)
            {
                empRepo.UnassignOrder(unassignOrderViewModel.EmployeeID.GetValueOrDefault(), unassignOrderViewModel.OrderID.GetValueOrDefault());
            }

            return Redirect("/Employee");
        }


        
       
        public IActionResult Login()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }

    }
}