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
    public class CustomerController : Controller
    {

        // a private TrailerOrderDbContext object that will be used within the class to interface with the database

        private readonly TrailerOrderDbContext context;

        // create a constructor that takes the TrailerDbContext object as a parameter
        // so that you can have access to the class in the framework(from the "startup.cs" file)

        public CustomerController(TrailerOrderDbContext dbContext)
        {
            this.context = dbContext;
        }



        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Customer> customers = context.Customers.ToList();
            return View(customers);
        }





        // GET: /<controller>/
        public IActionResult Add()
        {
            AddCustomerViewModel addCustomerViewModel = new AddCustomerViewModel();
            return View(addCustomerViewModel);
        }


        [HttpPost]
        public IActionResult Add(AddCustomerViewModel addCustomerViewModel)
        {
            if (ModelState.IsValid)
            {
                Customer newCustomer = new Customer
                {
                    CustomerName = addCustomerViewModel.CustomerName,
                    StreetNumber = addCustomerViewModel.StreetNumber,
                    StreetName = addCustomerViewModel.StreetName,
                    City = addCustomerViewModel.City,
                    ZipCode = addCustomerViewModel.ZipCode,
                    State = addCustomerViewModel.State
                };

                //add to customer data to Customer table
                context.Customers.Add(newCustomer);
                //always save changes
                context.SaveChanges();

                return Redirect("/Customer");
            };
            return View(addCustomerViewModel);

        }





        // GET: /<controller>/
        public IActionResult Remove()
        {
            return View();
        }



        // GET: /<controller>/
        public IActionResult CustomerInfo(int id)
        {

            //System.Diagnostics.Debug.WriteLine(id.ToString());
            if (id == 0){
                return Redirect("/Customer");
            }

            Customer customerInfo = context.Customers.Single(t => t.CustomerID == id);
            return View(customerInfo);
        }

    }
}
