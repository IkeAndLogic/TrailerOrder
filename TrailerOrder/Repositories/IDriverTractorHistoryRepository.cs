using System;
using System.Collections.Generic;
using TrailerOrder.Models;

namespace TrailerOrder.Repositories
{
    public interface IDriverTractorHistoryRepository
    {
        DriverTractorAssignmentHistory AddHistory(Employee employee, Tractor tractor);
        void CompleteHistory(Employee employee, Tractor tractor);
        IList<DriverTractorAssignmentHistory> DriverTractorHistory(DateTime dateOfAssignment);
        IList<DriverTractorAssignmentHistory> GetAllDriverToTractorHistory(Employee employee);
        IList<DriverTractorAssignmentHistory> GetAllTractortoDriverHistory(Tractor tractor);
        IList<DriverTractorAssignmentHistory> getDriverTractorHistoryByDate(Employee employee, Tractor tractor, DateTime dateTime);
        bool RemoveHistory(Employee employee, Tractor tractor);
    }
}