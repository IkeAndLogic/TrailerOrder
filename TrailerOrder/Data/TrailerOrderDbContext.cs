﻿using Microsoft.EntityFrameworkCore;
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

        //this DbSet will be used to interact with Attendance record table
        public DbSet<Attendance> Attendances { get; set; }

        ////this DbSet will be used to interact with completed Order table
        //public DbSet<Order> CompletedOrders { get; set; }


        //this DbSet will be used to interact with Tractor table
        public DbSet<Tractor> Tractors { get; set; }

        public TrailerOrderDbContext(DbContextOptions<TrailerOrderDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            


        }
    }
}
