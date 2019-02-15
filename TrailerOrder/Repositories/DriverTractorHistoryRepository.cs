using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrailerOrder.Data;
using TrailerOrder.Models;

namespace TrailerOrder.Repositories
{
    public class DriverTractorHistoryRepository : IDriverTractorHistoryRepository
    {

        // a private TrailerOrderDbContext object that will be used within the class to interface with the database

        private readonly TrailerOrderDbContext context;

        public DriverTractorHistoryRepository(TrailerOrderDbContext dbContext)
        {
            this.context = dbContext;
        }

        ////////////// All DriverTractorHistories will be moved to Driver ///////////////////

        // this method will Add new driverTractorHistory to driverHistories Table
        public DriverTractorAssignmentHistory AddHistory(Employee employee, Tractor tractor)
        {
            DriverTractorAssignmentHistory history = new DriverTractorAssignmentHistory(employee, tractor);
            context.DriverTractorsAssignmentHistory.Add(history);
            context.SaveChanges();
            return history;
        }

        // this method will Remove a particular driverTractorHistory
        public bool RemoveHistory(Employee employee, Tractor tractor)
        {
            DriverTractorAssignmentHistory history = context.DriverTractorsAssignmentHistory.Where(dt => dt.DateTimeUnassigned == null).Where(trac => trac.TractorId == tractor.TractorID).Single();
            if (history != null)
            {
                //System.Diagnostics.Debug.WriteLine(employee.EmployeeID);
                context.DriverTractorsAssignmentHistory.Remove(history);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        // this method will Add new driverTractorHistories
        public void CompleteHistory(Employee employee,Tractor tractor)
        {
            DriverTractorAssignmentHistory history = context.DriverTractorsAssignmentHistory.Where(dt => dt.DateTimeUnassigned == null).Where(trac => trac.TractorId == tractor.TractorID).Where(emp => emp.EmployeeId == employee.EmployeeID).Single();
            if (history != null)
            {
                DateTime dateTime = DateTime.Now;
                history.DateTimeUnassigned = dateTime;
            }
            context.SaveChanges();
        }

        //public DriverTractorAssignmentHistory Edit(Employee employee, Tractor tractor, DateTime)
        //{
        //    DriverTractorAssignmentHistory history = new DriverTractorAssignmentHistory(employee, tractor);
        //    context.DriverTractorsAssignmentHistory.Add(history);
        //    context.SaveChanges();
        //    return history;
        //}

        // this method will get history driverTractorHistories by a particularDate
        public IList <DriverTractorAssignmentHistory> getDriverTractorHistoryByDate(Employee employee, Tractor tractor, DateTime dateTime)
        {
           IList<DriverTractorAssignmentHistory> history = context.DriverTractorsAssignmentHistory.Where(dt => dt.DateTimeAssigned == dateTime).Include(emp => emp.EmployeeId == employee.EmployeeID).Include(trac => trac.TractorId == tractor.TractorID).ToList();
            return history;
        }
        
        // this method will return all driverTractorHistories from a particular Date in an  ascending Order
        public IList<DriverTractorAssignmentHistory> DriverTractorHistory(DateTime dateOfAssignment)
        {
            IList<DriverTractorAssignmentHistory> DriverTractorHistories = context.DriverTractorsAssignmentHistory.Where(dt => dt.DateTimeAssigned >= dateOfAssignment).OrderBy(dt => dt.DateTimeAssigned.TimeOfDay).ToList();
            return DriverTractorHistories;
        }

        // this method will all driverTractorHistories for a particular Employee
        public IList<DriverTractorAssignmentHistory> GetAllDriverToTractorHistory(Employee employee)
        {
            IList<DriverTractorAssignmentHistory> DriverTractorHistories = context.DriverTractorsAssignmentHistory.Where(dt => dt.EmployeeId == employee.EmployeeID).ToList();
            return DriverTractorHistories;
        }

        // this method will all driverTractorHistories for a particular Tractor
        public IList<DriverTractorAssignmentHistory> GetAllTractortoDriverHistory(Tractor tractor)
        {
            IList<DriverTractorAssignmentHistory> DriverTractorHistories = context.DriverTractorsAssignmentHistory.Where(dt => dt.TractorId == tractor.TractorID).ToList();
            return DriverTractorHistories;
        }

    }
}
