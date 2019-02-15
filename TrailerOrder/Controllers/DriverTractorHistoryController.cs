using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrailerOrder.Models;
using TrailerOrder.Repositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrailerOrder.Controllers
{
    public class DriverTractorHistoryController : Controller
    {

        private IDriverTractorHistoryRepository dtRepo;
        private IEmployeesRepository empRepo;
        private ITractorRepository trucRepo;

        public DriverTractorHistoryController(IDriverTractorHistoryRepository dtRepo, IEmployeesRepository empRepo, ITractorRepository trucRepo)
        {
            this.dtRepo = dtRepo;
            this.empRepo = empRepo;
            this.trucRepo = trucRepo;
        } 
        
           
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


        // GET: /<controller>/
        public IActionResult Edit()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Edit(Employee employee, Tractor tractor)
        {
            return View();
        }


        //// GET: /<controller>/
        //public IActionResult Remove()
        //{
        //    return View();
        //}


        //[HttpPost]
        //public IActionResult Remove(int employee, Tractor tractor)
        //{
        //    return View();
        //}
    }
}
