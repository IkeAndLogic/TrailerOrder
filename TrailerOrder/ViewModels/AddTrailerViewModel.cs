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
        public string SerialNumber { get; set; }

        

        [Required(ErrorMessage = "You must assign a Trailer number")]
        public string TrailerNumber { get; set; }

        public string TodaysDate { get; set; }

        public AddTrailerViewModel()
        {
            TodaysDate = DateTime.Now.ToShortDateString();
        }

    }

}
