using System.Collections.Generic;
using TrailerOrder.Models;

namespace TrailerOrder.Repositories
{
    public interface IEmployeesRepository
    {
        Employee CreateEmployee(Employee newEmployee);
        Employee Edit(Employee employeeToEdit);
        List<Employee> GetAllEmployees();
        Employee GetEmployeeWithId(int id);
        bool RemoveEmployee(int[] employeeIds);
    }
}