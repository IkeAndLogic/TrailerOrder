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






        public IActionResult TrailerDetails(int id)
        {
            Trailer trailerinfo = context.Trailers.Single(t => t.TrailerID == id);
            return View(trailerinfo);
        }





        //displays form
        public IActionResult Add()
        {
            AddTrailerViewModel addtrailerViewModel = new AddTrailerViewModel();
            return View(addtrailerViewModel);
        }


        [HttpPost]
        public IActionResult Add(AddTrailerViewModel addTrailerViewModel)
        {
            if (ModelState.IsValid)
            {
                Trailer newTrailer = new Trailer
                {
                    SerialNumber = addTrailerViewModel.SerialNumber,
                    TrailerNumber = addTrailerViewModel.TrailerNumber,
                    TrailerMake = addTrailerViewModel.TrailerMake,
                    TrailerModel = addTrailerViewModel.TrailerModel,
                    Year = addTrailerViewModel.Year,
                    InspDate = addTrailerViewModel.InspDate,
                    RegDate = addTrailerViewModel.RegDate,
                };

                //add to tractorData
                context.Trailers.Add(newTrailer);
                //always save changes
                context.SaveChanges();

                return Redirect("/Trailer/");
            };
            return View(addTrailerViewModel);

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



                if (removeTrailer.TrailerStatus == "Available"){

                    context.Trailers.Remove(removeTrailer);

                    // need to display an error message on the remove form
                }

                else
                {
                    return Redirect("/Trailer/Remove");

                }

            }

            context.SaveChanges();
            return Redirect("/");
        }



        // httpGet
        public IActionResult Edit(int id)
        {
            Trailer trailerToEdit = context.Trailers.FirstOrDefault(t => t.TrailerID == id);
            EditTrailerViewModel editTrailerViewModel = new EditTrailerViewModel
            {
                SerialNumber = trailerToEdit.SerialNumber,
                TrailerNumber = trailerToEdit.TrailerNumber,
                TrailerMake = trailerToEdit.TrailerMake,
                TrailerModel = trailerToEdit.TrailerModel,
                Year = trailerToEdit.Year,
                InspDate = trailerToEdit.InspDate,
                RegDate = trailerToEdit.RegDate,
                TrailerID = trailerToEdit.TrailerID
            };

            return View(editTrailerViewModel);
        }



        [HttpPost]
        public IActionResult Edit(EditTrailerViewModel editTrailerViewModel)
        {

            Trailer trailerToEdit = context.Trailers.FirstOrDefault(t => t.TrailerID == editTrailerViewModel.TrailerID);

            if (ModelState.IsValid)
            {
                trailerToEdit.TrailerID = editTrailerViewModel.TrailerID;
                trailerToEdit.SerialNumber = editTrailerViewModel.SerialNumber;
                trailerToEdit.TrailerNumber = editTrailerViewModel.TrailerNumber;

                trailerToEdit.TrailerMake = editTrailerViewModel.TrailerMake;
                trailerToEdit.TrailerModel = editTrailerViewModel.TrailerModel;
                trailerToEdit.Year = editTrailerViewModel.Year;
                trailerToEdit.InspDate = editTrailerViewModel.InspDate;
                trailerToEdit.RegDate = editTrailerViewModel.RegDate;

                //always save changes
                context.SaveChanges();

                return Redirect("/Trailer");
            };
            return View(editTrailerViewModel);
        }




    }
}

