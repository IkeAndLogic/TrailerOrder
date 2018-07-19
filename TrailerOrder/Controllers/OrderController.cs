using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrailerOrder.Data;
using TrailerOrder.Models;
using TrailerOrder.ViewModels;

namespace TrailerOrder.Controllers
{
    public class OrderController : Controller
    {


        Trailer trailerSelected = new Trailer();

        // a private EpmloyeeDBContext object that will be used within the class to interface with the database
        private readonly TrailerOrderDbContext context;

        // create a constructor that takes the OrderDbContext object as a parameter
        // so that you can have access to the class in the framework(from the "startup.cs" file)
        public OrderController(TrailerOrderDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            //Order list will populate all orders and include the Trailer object as well
            //the Trailer object is necessary to access the trailer number attached to the order 
            List<Order> orders = context.Orders.Include(t => t.TrailerForLoad).Include(c => c.CustomerOrders).ToList();

            return View(orders);
        }


        public IActionResult Add()
        {
            // holds in the list of available trailers 
            IList<Trailer> trailerForLoad = context.Trailers.Where(c => c.TrailerStatus == "Available").ToList();

            // to hold a list of customers in the the Customer table 
            IList<Customer> customerOrder = context.Customers.ToList();

            // passes both lists to the AddOrderViewModel constructor to make the available in the form
            AddOrderViewModel addOrderViewModel = new AddOrderViewModel(trailerForLoad, customerOrder);



            return View(addOrderViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddOrderViewModel addOrderViewModel)
        {
            if (ModelState.IsValid)
            {

                Order newOrder = new Order()
                {
                    OrderNumber = addOrderViewModel.OrderNumber,
                    DueDate = addOrderViewModel.DueDate,
                    Driver = null,
                    //matches the 
                    TrailerForLoad = context.Trailers.Where(x => x.TrailerID == addOrderViewModel.TrailerID).Single(),
                    CustomerOrders = context.Customers.Single(x => x.CustomerID== addOrderViewModel.CustomerID)

                };

                context.Orders.Add(newOrder);

                trailerSelected = context.Trailers.Where(x => x.TrailerID == addOrderViewModel.TrailerID).Single();


                //newOrder.TrailerForLoad = trailerSelected;

                trailerSelected.TrailerStatus = "Unavailable";

               
                context.SaveChanges();

                return Redirect("/Order");
            }


            return View(addOrderViewModel);
        }

        //gets details for individual load mapped by id
        public IActionResult OrderInfo(int id)
        {
            //linq query includes the trailer object for access to associted trailer properties and a single id of order
            Order orderInfo = context.Orders.Include(c => c.TrailerForLoad).ToList().Single(o => o.OrderID == id);

            return View(orderInfo);
        }



        public IActionResult Remove()
        {
            RemoveOrderViewModel removeOrderViewModel = new RemoveOrderViewModel(context.Orders.ToList());

            return View(removeOrderViewModel);

        }


        [HttpPost]
        public IActionResult Remove(int[] orderIds)
        {
            foreach (int orderId in orderIds)
            {
                Order removeOrder = context.Orders.Include(t => t.TrailerForLoad).ToList().Single(c => c.OrderID == orderId);
                removeOrder.TrailerForLoad.TrailerStatus = "Available";
                context.Orders.Remove(removeOrder);
            }
            context.SaveChanges();
            return Redirect("/");
        }

        public IActionResult Edit(int id)
        {
            //ViewData["Title"]="Edit";

            Order orderToEdit = context.Orders.FirstOrDefault(x => x.OrderID==id) ;

            // holds in the list of available trailers including the one that is already assigned to it 
            IList<Trailer> trailerForLoad = context.Trailers.Where(x => x.TrailerStatus == "Available" || x.TrailerID == orderToEdit.TrailerForLoadID).ToList();

            // to hold a list of customers in the the Customer table 
            IList<Customer> customerOrder = context.Customers.ToList();

            // passes Order Object and both lists to the EditOrderViewModel constructor to make the available in the form
            EditOrderViewModel editOrderViewModel = new EditOrderViewModel(orderToEdit, trailerForLoad, customerOrder);

            return View(editOrderViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditOrderViewModel editOrderViewModel)
        {

            //trailerSelected = context.Trailers.Where(x => x.TrailerID == editOrderViewModel.TrailerForLoadID).Single();

            Order order= context.Orders.FirstOrDefault(o => o.OrderID==editOrderViewModel.OrderID);
            Trailer newTrailer = context.Trailers.FirstOrDefault(t => t.TrailerID == editOrderViewModel.TrailerForLoadID);
            Trailer oldTrailer = context.Trailers.FirstOrDefault(t => t.TrailerID == order.TrailerForLoadID);


            order.OrderNumber = editOrderViewModel.OrderNumber;
            order.CustomerOrdersID = editOrderViewModel.CustomerOrdersID;
            //if (order.TrailerForLoadID != trailerSelected.TrailerID){
            //   order.TrailerForLoad.TrailerStatus = "Available";
            //   trailerSelected.TrailerStatus = "Unavailable";
            //}
            if (oldTrailer.TrailerID!=newTrailer.TrailerID)
            {
                oldTrailer.TrailerStatus = "Available";
                newTrailer.TrailerStatus = "Unavailable";
            }
            order.TrailerForLoadID = newTrailer.TrailerID; //editOrderViewModel.TrailerForLoadID;
            //save changes
            context.SaveChanges();
            return Redirect("/");
            
        }

    }
}

