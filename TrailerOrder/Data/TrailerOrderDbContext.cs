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

        

        //this DbSet will be used to interact with Tractor Database
        public DbSet<Trailer> Trailers { get; set; }

        

        //this DbSet will be used to interact with Order Database
        public DbSet<Order> Orders { get; set; }

        public TrailerOrderDbContext(DbContextOptions<TrailerOrderDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<EmployeeWorkDayData>().HasKey(t => new { t.EmployeeWorkDayID, t.EmployeeID});


        }
    }
}
