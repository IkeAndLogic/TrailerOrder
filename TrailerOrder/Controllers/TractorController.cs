using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrailerOrder.Data;
using TrailerOrder.Models;
using TrailerOrder.Repositories;
using TrailerOrder.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrailerOrder.Controllers
{
    public class TractorController : Controller
    {


        //private readonly TrailerOrderDbContext context;

        //public TractorController(TrailerOrderDbContext dbContext)
        //{
        //    context = dbContext;
        //}


        private ITractorRepository repo;

        public TractorController(ITractorRepository repo)
        {
            this.repo = repo;
        }


        // gets all 
        public IActionResult Index()
        {
            List<Tractor> tractors = repo.GetAllTractor();

            return View(tractors);
        }


        //gets details for individual trailer mapped by id
        public IActionResult TractorDetails(int id)
        {
            Tractor tractorinfo = repo.GetTractorWithId(id);

            return View(tractorinfo);
        }


        // httpGet
        public IActionResult Add()
        {
            AddTractorViewModel addtractorViewModel = new AddTractorViewModel();

            return View(addtractorViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddTractorViewModel addtractorViewModel)
        {
            if (ModelState.IsValid)
            {
                Tractor newTractor = new Tractor
                {
                    TruckNumber = addtractorViewModel.TruckNumber,
                    TractorMake = addtractorViewModel.TractorMake,
                    TractorModel = addtractorViewModel.TractorModel,
                    Year = addtractorViewModel.Year,
                    VinNumber = addtractorViewModel.VinNumber,
                    PlateNumber = addtractorViewModel.PlateNumber,
                    DotInp = addtractorViewModel.DotInp,
                    RegDate = addtractorViewModel.RegDate,
                    DateAssigned = DateTime.Now,
                };
                //add to tractorData and saves it
                repo.Add(newTractor);           
                return Redirect("/Tractor");
            };
            return View(addtractorViewModel);
        }

        // the removeTractorViewModel will recieve a list of available Tractors in
        public IActionResult Remove()
        {
            RemoveTractorViewModel removeTractorViewModel = new RemoveTractorViewModel(repo.GetAllTractor());
            return View(removeTractorViewModel);
        }


        [HttpPost]
        public IActionResult Remove(int[] tractorIds)
        {
            // we are doing two things here; calling the function, and also checking if it returns false
            if (repo.Remove(tractorIds) == false)
            {
                return Redirect("/Tractor/Remove");
            }
            return Redirect("/Tractor");

        }

        // httpGet
        public IActionResult Edit(int id)
        {

            Tractor tractorToEdit = repo.GetTractorWithId(id);

            EditTractorViewModel editTractorViewModel = new EditTractorViewModel
            {
                TractorID =tractorToEdit.TractorID,
                TruckNumber = tractorToEdit.TruckNumber,
                TractorMake = tractorToEdit.TractorMake,
                TractorModel = tractorToEdit.TractorModel,
                Year = tractorToEdit.Year,
                VinNumber = tractorToEdit.VinNumber,
                PlateNumber = tractorToEdit.PlateNumber,
                DotInp = tractorToEdit.DotInp,
                RegDate = tractorToEdit.RegDate
            };

            return View(editTractorViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditTractorViewModel editTractorViewModel)
        {

            Tractor tractor = new Tractor() {
            TractorID = editTractorViewModel.TractorID,
            TruckNumber = editTractorViewModel.TruckNumber,
            TractorMake = editTractorViewModel.TractorMake,
            TractorModel = editTractorViewModel.TractorModel,
            Year = editTractorViewModel.Year,
            VinNumber = editTractorViewModel.VinNumber,
            PlateNumber = editTractorViewModel.PlateNumber,
            DotInp = editTractorViewModel.DotInp,
            RegDate = editTractorViewModel.RegDate
        };

            if (ModelState.IsValid)
            {
                repo.Edit(tractor);
                return Redirect("/Tractor");
            };
            return View(editTractorViewModel);
        }









    }
}

