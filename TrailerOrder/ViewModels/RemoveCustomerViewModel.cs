﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrailerOrder.Models;

namespace TrailerOrder.ViewModels
{
    public class RemoveCustomerViewModel
    {

        public List<Customer> Customers { get; set; }



        public RemoveCustomerViewModel(List<Customer> customers)
        {
            Customers = customers;
        }



    }
}
