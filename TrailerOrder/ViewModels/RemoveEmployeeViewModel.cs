using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrailerOrder.Models;

namespace TrailerOrder.ViewModels
{
    public class RemoveEmployeeViewModel
    {

        public List<Employee> Employees { get; set; }



        public RemoveEmployeeViewModel(List<Employee> employee)
        {
            Employees = employee;
        }

    }
}
