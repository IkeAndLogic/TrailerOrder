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

            List<Order> orders = context.Orders.ToList();

            return View(orders);
        }


        public IActionResult Add()
        {
            // passes in the list of available trailers in the order form
            IList<Trailer> trailerForLoad = context.Trailers.Include(c => c.TrailerStatus == "Avaliable").ToList();

            AddOrderViewModel addOrderViewModel = new AddOrderViewModel(trailerForLoad);

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
                    

                    //matches the 
                    TrailerForLoad = context.Trailers.Where(x => x.TrailerID == addOrderViewModel.TrailerID).Single()



                };

                context.Orders.Add(newOrder);

                trailerSelected = context.Trailers.Where(x => x.TrailerID == addOrderViewModel.TrailerID).Single();

                trailerSelected.TrailerStatus = "Unavilable";
                context.SaveChanges();

                return Redirect("/Order");
            }


            return View(addOrderViewModel);
        }

        //gets details for individual load mapped by id
        public IActionResult OrderInfo(int id)
        {
            Order orderInfo = context.Orders.Single(o => o.OrderID == id);

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

                Order removeOrder = context.Orders.Single(c => c.OrderID == orderId);

                context.Orders.Remove(removeOrder);

            }

            //AddOrderViewModel addOrderViewModel = new AddOrderViewModel();
            // trailerSelected = context.Trailers.Where(x => x.TrailerID == addOrderViewModel.TrailerID).Single();

            //trailerSelected.Status = "Available";

            context.SaveChanges();
            return Redirect("/");
        }



















    }
}
