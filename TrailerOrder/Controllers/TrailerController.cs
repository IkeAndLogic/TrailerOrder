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
    public class TrailerController : Controller
    {



        // a private ClockInDBContext object that will be used within the class to interface with the database

        private readonly TrailerOrderDbContext context;

        // create a constructor that takes the TrailerDbContext object as a parameter
        // so that you can have access to the class in the framework(from the "startup.cs" file)

        public TrailerController(TrailerOrderDbContext dbContext)
        {
            context = dbContext;
        }




        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Trailer> trailers = context.Trailers.ToList();

            return View(trailers);

        }


        //displays form
        public IActionResult Add()
        {
            AddTrailerViewModel addtrailerViewModel = new AddTrailerViewModel();

            return View(addtrailerViewModel);
        }



        public IActionResult TrailerInfo(int id)
        {
            Trailer trailerinfo = context.Trailers.Single(t => t.TrailerID == id);

            return View(trailerinfo);
        }



        [HttpPost]
        public IActionResult Add(AddTrailerViewModel addtrailerViewModel)
        {
            if (ModelState.IsValid)
            {
                Trailer newTrailer = new Trailer
                {
                    SerialNumber = addtrailerViewModel.SerialNumber,
                    TrailerNumber = addtrailerViewModel.TrailerNumber
                };

                //add to tractorData
                context.Trailers.Add(newTrailer);
                //always save changes
                context.SaveChanges();

                return Redirect("/Trailer");
            };
            return View(addtrailerViewModel);

        }






        public IActionResult Remove()
        {
            RemoveTrailerViewModel removeTrailerViewModel = new RemoveTrailerViewModel(context.Trailers.ToList());

            return View(removeTrailerViewModel);

        }


        [HttpPost]
        public IActionResult Remove(int[] trailerIds)
        {
            foreach (int trailerId in trailerIds)
            {

                Trailer removeTrailer = context.Trailers.Single(c => c.TrailerID == trailerId);



                if (removeTrailer.TrailerStatus != "Available"){

                    return Redirect("/Trailer/Remove");

                    // need to display an error message on the remove form
                }

                else
                {
                    context.Trailers.Remove(removeTrailer);
                }

            }

            context.SaveChanges();
            return Redirect("/");
        }

    }
}

