using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrailerOrder.ViewModels
{
    public class AddTractorViewModel
    {
        public int TractorID { get; set; }

        [Required(ErrorMessage = "You must assign a truck number ")]
        [Display(Name = "Truck Number")]
        public string TruckNumber { get; set; }

        [Required(ErrorMessage = "You must provide the Tractor manufacturer's name ")]
        [Display(Name = "Tractor Make")]
        public string TractorMake { get; set; }

        [Required(ErrorMessage = "You must provide the Tractor Model")]
        [Display(Name ="Tractor Model")]
        public string TractorModel { get; set; }

        [Required(ErrorMessage = "You must provide the Tractor Year")]
        [Display(Name = "Tractor Year")]
        public string Year { get; set; }

        [Required(ErrorMessage = "You must provide the vehicle identification number")]
        [Display(Name = "Vehicle Identification Number")]
        public string VinNumber { get; set; }

        [Required(ErrorMessage = "You must provide the Plate Number")]
        [Display(Name = "Plate Number")]
        public string PlateNumber { get; set; }

        [Required(ErrorMessage = "You must provide the D.O.T Inspection Date"), DataType(DataType.Date)]
        [Display(Name = "D.O.T Inspection Date")]
        public DateTime DotInp { get; set; }

        [Required(ErrorMessage = "You must provide the Registration Date"), DataType(DataType.Date)]
        [Display(Name = "Resgitration Date")]
        public DateTime RegDate { get; set; }

        public string TodaysDate { get; set; }


        public AddTractorViewModel()
        {
            TodaysDate = DateTime.Now.ToShortDateString();

        }

    }
}
