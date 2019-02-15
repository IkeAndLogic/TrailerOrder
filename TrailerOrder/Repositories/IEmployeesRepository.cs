using System.Collections.Generic;
using TrailerOrder.Models;

namespace TrailerOrder.Repositories
{
    public interface IEmployeesRepository
    {
        Employee AssignOrder(int EmployeeId, int OrderId);
        Employee AssignTractor(int employeeId, int tractorId);
        Employee CreateEmployee(Employee newEmployee);
        Employee Edit(Employee employeeToEdit);
        List<Employee> GetAllEmployees();
        IList<Order> GetAvailableOrders();
        Employee GetEmployeeWithId(int id);
        Order GetOrderWithId(int id);
        bool RemoveEmployee(int[] employeeIds);
        Employee UnassignOrder(int EmployeeId, int OrderId);
        Employee UnassignTractor(int employeeId);
    }
}