//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using TrailerOrder.Data;
//using TrailerOrder.Models;
//using TrailerOrder.ViewModels;

//// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace TrailerOrder.Controllers
//{
//    public class CompletedOrdersController : Controller
//    {
//        // a private TrailerOrderDbContext object that will be used within the class to interface with the database
//        private readonly TrailerOrderDbContext context;

//        public CompletedOrdersController(TrailerOrderDbContext dbContext)
//        {
//            context = dbContext;
//        }


//        public ActionResult Index()
//        {
//            List<CompletedOrders> completedOrders = context.DriverCompletedOrders.ToList();

//            return View(completedOrders);
//        }




//        public ActionResult CompleteOrder(int id)
//        {
//            Order allCompletedOrders = context.Orders.Where(ord => ord.CustomerOrdersID == id).Single();

//            //NewCompletedOrderViewModel newCompletedOrderViewModel = new NewCompletedOrderViewModel();


//            return View(allCompletedOrders);
//        }

//        [HttpPost]
//        public ActionResult Create()
//        {
//            List<CompletedOrders> completedOrders = context.DriverCompletedOrders.ToList();

//            return View(completedOrders);
//        }


//    }
//}
