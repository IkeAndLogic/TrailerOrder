using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrailerOrder.Data;
using TrailerOrder.Models;

namespace TrailerOrder.Repositories
{
    public class TrailerRepository : ITrailerRepository
    {
        // a private TrailerOrderDbContext object that will be used within the class to interface with the database

        private readonly TrailerOrderDbContext context;


        public TrailerRepository(TrailerOrderDbContext dbContext)
        {
            this.context = dbContext;
        }


        
        public List<Trailer> GetAvailableTrailers()
        {
            List<Trailer> availableTrailers = context.Trailers.Where(x => x.TrailerStatus == "Available").ToList();

            return availableTrailers;
        }



        public Trailer GetTrailerWithId(int id)
        {
            Trailer getTrailerWithId = context.Trailers.SingleOrDefault(x => x.TrailerID == id);
            return getTrailerWithId;
        }

    }
}
