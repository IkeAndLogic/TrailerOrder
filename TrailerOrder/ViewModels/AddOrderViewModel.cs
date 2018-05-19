using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TrailerOrder.Models;

namespace TrailerOrder.ViewModels
{
    public class AddOrderViewModel
    {
        [Required(ErrorMessage = "Must Provide Order Number")]
        public string OrderNumber { get; set; }

       

        public int TrailerID { get; set; }

        public List<SelectListItem> TrailersForLoad { get; set; }



        public AddOrderViewModel(IEnumerable<Trailer> trailersForLoad)
        {

            TrailersForLoad = new List<SelectListItem>();

            foreach (var trailer in trailersForLoad)

            {
                TrailersForLoad.Add(new SelectListItem

                {
                    Value = (trailer.TrailerID).ToString(),
                    Text = trailer.TrailerNumber
                });
            }







        }

    }
}
