using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrailerOrder.Models;

namespace TrailerOrder.ViewModels
{
    public class RemoveTrailerViewModel
    {

        
        public List<Trailer> Trailers { get; set; }
       



        public RemoveTrailerViewModel(List<Trailer> trailers)
        {
            Trailers = trailers;
        }
    }
}
