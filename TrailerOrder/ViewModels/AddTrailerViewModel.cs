using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrailerOrder.ViewModels
{
    public class AddTrailerViewModel
    {
        [Required(ErrorMessage = "You must provide the vin number")]
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }
      
        [Required(ErrorMessage = "You must assign a Trailer number")]
        [Display(Name = "Trailer Number")]
        public string TrailerNumber { get; set; }

        [Required(ErrorMessage = "You must assign a Trailer Make")]
        [Display(Name = "Trailer Make")]
        public string TrailerMake { get; set; }

        [Required(ErrorMessage = "You must assign a Trailer Model")]
        [Display(Name = "Trailer Model")]
        public string TrailerModel { get; set; }

        [Required(ErrorMessage = "You must assign a Year")]
        [Display(Name = "Year")]
        public string Year { get; set; }

        [Required(ErrorMessage = "You must assign a Regstration Date"), DataType(DataType.Date)]
        [Display(Name = "Registration Date")]
        public DateTime RegDate { get; set; }

        [Required(ErrorMessage = "You must assign a Inspection Date"), DataType(DataType.Date)]
        [Display(Name = "Inspection Date")]
        public DateTime InspDate { get; set; }


        public int TrailerID { get; set; }

        public string TodaysDate { get; set; }

        public AddTrailerViewModel()
        {
            TodaysDate = DateTime.Now.ToShortDateString();
        }

    }

}
