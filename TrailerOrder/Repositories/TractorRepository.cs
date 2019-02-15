using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrailerOrder.Data;
using TrailerOrder.Models;

namespace TrailerOrder.Repositories
{
    public class TractorRepository : ITractorRepository
    {
        // a private TrailerOrderDbContext object that will be used within the class to interface with the database

        private readonly TrailerOrderDbContext context;


        public TractorRepository(TrailerOrderDbContext dbContext)
        {
            this.context = dbContext;
        }

        //gets all available tractors
        public List<Tractor> GetAvailableTractor()
        {
            List<Tractor> availableTractors = context.Tractors.Where(x => x.Status == "Available").ToList();

            return availableTractors;
        }


        //gets all tractors
        public List<Tractor> GetAllTractor()
        {
            List<Tractor> availableTractors = context.Tractors.ToList();

            return availableTractors;
        }

        // gets a particular tractor with id
        public Tractor GetTractorWithId(int id)
        {
            Tractor getTractorWithId = context.Tractors.SingleOrDefault(x => x.TractorID == id);
            return getTractorWithId;
        }



        // changes the avilablity of particular tractor with id
        public Tractor ChangeStatusWithId(int id)
        {
            Tractor tractorToChangeStatus = context.Tractors.SingleOrDefault(x => x.TractorID == id);

            if (tractorToChangeStatus.Status == "Available")
            {
                tractorToChangeStatus.Status = "Unavailable";
                context.SaveChanges();
            }
            else if (tractorToChangeStatus.Status == "Unavailable")
            {
                tractorToChangeStatus.Status = "Available";
                context.SaveChanges();
            }
            return tractorToChangeStatus;
        }

        // adds new Tractor to Tractors Table
        public Tractor Add(Tractor tractor)
        {
            context.Tractors.Add(tractor);
            context.SaveChanges();
            return tractor;
        }


        // edits Tractor data
        public Tractor Edit(Tractor tractor)
        {
            Tractor tractorToBeEdited = GetTractorWithId(tractor.TractorID);

            tractorToBeEdited.TruckNumber = tractor.TruckNumber;
            tractorToBeEdited.TractorMake = tractor.TractorMake;
            tractorToBeEdited.TractorModel = tractor.TractorModel;
            tractorToBeEdited.Year = tractor.Year;
            tractorToBeEdited.VinNumber = tractor.VinNumber;
            tractorToBeEdited.PlateNumber = tractor.PlateNumber;
            tractorToBeEdited.DotInp = tractor.DotInp;
            tractorToBeEdited.RegDate = tractor.RegDate;

            context.SaveChanges();
            //System.Diagnostics.Debug.WriteLine(tractorToBeEdited.TruckNumber);
            return tractorToBeEdited;
        }

        // Remove a particular Tractor
        public bool Remove(int tractorId)
        {
            Tractor tractorToBeRemoved = GetTractorWithId(tractorId);

            if (tractorToBeRemoved!= null) {
                context.Tractors.Remove(tractorToBeRemoved);
                context.SaveChanges();
                return true;
            }
            return false;
        }




        //removes many tractors at once
        public bool Remove(int[] tractorIds)
        {
            foreach (int tractorId in tractorIds)
            {
                Tractor removeTractor = context.Tractors.Single(c => c.TractorID == tractorId);                
                if (removeTractor != null && removeTractor.Status == "Available")
                {
                    context.Tractors.Remove(removeTractor);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }



    }
}
