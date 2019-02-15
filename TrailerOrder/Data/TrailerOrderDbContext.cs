using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrailerOrder.Models;

namespace TrailerOrder.Data
{
    public class TrailerOrderDbContext:DbContext
    {
        //this DbSet will be used to interact with Tractor table
        public DbSet<Trailer> Trailers { get; set; }

        //this DbSet will be used to interact with Order table
        public DbSet<Order> Orders { get; set; }

        //this DbSet will be used to interact with Customer table
        public DbSet<Customer> Customers { get; set; }

        //this DbSet will be used to interact with Employee table
        public DbSet<Employee> Employees { get; set; }

        ////this DbSet will be used to interact with Attendance record table
        //public DbSet<Attendance> Attendances { get; set; }

        ////this DbSet will be used to interact with completed Order table and Employee table
        //// it is a join table with Employee and Orders table
        //public DbSet<CompletedOrders> DriverCompletedOrders { get; set; }


        //this DbSet will store used to the history of Tractor table and Employee table 
        public DbSet<DriverTractorAssignmentHistory> DriverTractorsAssignmentHistory { get; set; }

        //this DbSet will be used to interact with Tractor table
        public DbSet<Tractor> Tractors { get; set; }

        public TrailerOrderDbContext(DbContextOptions<TrailerOrderDbContext> options)
            : base(options)
        {
        }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DriverTractorAssignmentHistory>().HasKey(co => new { co.EmployeeId, co.TractorId, co.DateTimeAssigned });

            modelBuilder.Entity<DriverTractorAssignmentHistory>()
            .HasOne(e => e.Driver)
            .WithMany(c => c.DriverTractorAssignmentHistories)
            .HasForeignKey(trac => trac.TractorId);

            modelBuilder.Entity<DriverTractorAssignmentHistory>()
            .HasOne(trac => trac.Tractor)
            .WithMany(c => c.DriverTractorAssignmentHistories)
            .HasForeignKey(e => e.EmployeeId);

            //modelBuilder.Entity<CompletedOrders>().HasKey(co => new { co.EmployeeId, co.OrderId });

            //modelBuilder.Entity<CompletedOrders>()
            //.HasOne(e => e.Employees)
            //.WithMany(c => c.CompletedOrders)
            //.HasForeignKey(ord => ord.OrderId);

            //modelBuilder.Entity<CompletedOrders>()
            //.HasOne(ord => ord.OrdersCompleted)
            //.WithMany(c => c.CompletedOrders)
            //.HasForeignKey(e => e.EmployeeId);
        }

    }
}
