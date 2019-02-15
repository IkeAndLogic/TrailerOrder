using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrailerOrder.Models;

namespace TrailerOrder.ViewModels
{
    public class AssignTractorViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int EmployeeID { get; set; }
        public int TractorID { get; set; }

        public List<SelectListItem> Tractors { get; set; }

        public string TruckNumber { get; set; }
        //public string TruckStatus { get; set; }


        public AssignTractorViewModel()
        {
        }



        public AssignTractorViewModel(Employee driver, IEnumerable<Tractor> tractors)
        {

            FirstName = driver.FirstName;
            LastName = driver.LastName;
            EmployeeID = driver.EmployeeID;

            Tractors = new List<SelectListItem>();

            foreach (var tractor in tractors)
            {
                Tractors.Add(new SelectListItem
                {
                    Value = (tractor.TractorID).ToString(),
                    Text = tractor.TruckNumber
                });
            };
        }

    }
}
