using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrailerOrder.Models;

namespace TrailerOrder.ViewModels
{
    public class RemoveTractorViewModel
    {

        public List<Tractor> Tractors { get; set; }


        public RemoveTractorViewModel(List<Tractor> tractors)
        {
            Tractors = tractors;
        }
    }
}
