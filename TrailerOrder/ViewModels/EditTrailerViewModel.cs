using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrailerOrder.ViewModels
{
    public class EditTrailerViewModel
    {
        [Required(ErrorMessage = "You must provide the Serial number")]
        [Display(Name ="Serial Number")]
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

        [Required(ErrorMessage = "You must assign a Trailer Year")]
        [Display(Name = "Year")]
        public string Year { get; set; }

        [Required(ErrorMessage = "You must assign a Registration Date"), DataType(DataType.Date)]
        [Display(Name = "Registraion Date")]
        public DateTime RegDate { get; set; }

        [Required(ErrorMessage = "You must assign a Inspection Date"), DataType(DataType.Date)]
        [Display(Name = "Inspection Date")]
        public DateTime InspDate { get; set; }



        public string TrailerStatus { get; set; }

        public int TrailerID { get; set; }

        public string TodaysDate { get; set; }

        public EditTrailerViewModel()
        {
            TodaysDate = DateTime.Now.ToShortDateString();
        }
    }
}
