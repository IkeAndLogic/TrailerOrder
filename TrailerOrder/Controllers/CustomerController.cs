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
            RemoveCustomerViewModel removeCustomerViewModel = new RemoveCustomerViewModel(context.Customers.ToList());
            return View(removeCustomerViewModel);
        }




        [HttpPost]
        public IActionResult Remove(int[] customerIds)
        {
            foreach (int customerId in customerIds)
            {
                Customer removeCustomer = context.Customers.Single(c => c.CustomerID == customerId);
                context.Customers.Remove(removeCustomer);                
            }
            context.SaveChanges();
            return Redirect("/Customer");
        }


            // GET: /<controller>/
            public IActionResult CustomerDetails(int id)
        {

            if (id == 0){
                return Redirect("/Customer");
            }

            Customer customerInfo = context.Customers.Single(t => t.CustomerID == id);
            return View(customerInfo);
        }






        // httpGet
        public IActionResult Edit(int id)
        {

            Customer customerToEdit = context.Customers.FirstOrDefault(c => c.CustomerID == id);

            //System.Diagnostics.Debug.WriteLine(customerToEdit.CustomerID);


            EditCustomerViewModel editCustomerViewModel = new EditCustomerViewModel
            {
                CustomerID = customerToEdit.CustomerID,
                CustomerName = customerToEdit.CustomerName,
                StreetNumber = customerToEdit.StreetName,
                StreetName = customerToEdit.StreetName,
                ZipCode = customerToEdit.ZipCode,
                City = customerToEdit.City,
                State = customerToEdit.State,
            };

            return View(editCustomerViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditCustomerViewModel editCustomerViewModel)
        {

            Customer customerToEdit = context.Customers.FirstOrDefault(t => t.CustomerID == editCustomerViewModel.CustomerID);

            if (ModelState.IsValid)
            {
                customerToEdit.CustomerID = editCustomerViewModel.CustomerID;
                customerToEdit.CustomerName = editCustomerViewModel.CustomerName;
                customerToEdit.StreetNumber = editCustomerViewModel.StreetNumber;
                customerToEdit.StreetName = editCustomerViewModel.StreetName;
                customerToEdit.ZipCode = editCustomerViewModel.ZipCode;
                customerToEdit.City = editCustomerViewModel.City;
                customerToEdit.State = editCustomerViewModel.State;

                //always save changes
                context.SaveChanges();

                return Redirect("/Customer/CustomerDetails");
            };
            return View(editCustomerViewModel);
        }















    }
}
