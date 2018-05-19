﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrailerOrder.Models;

namespace TrailerOrder.ViewModels
{
    public class RemoveOrderViewModel
    {
        public List<Order> Orders { get; set; }



        public RemoveOrderViewModel(List<Order> orders)
        {
            Orders = orders;
        }
    }
}
