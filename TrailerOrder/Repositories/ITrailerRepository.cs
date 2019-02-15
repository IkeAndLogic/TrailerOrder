using System.Collections.Generic;
using TrailerOrder.Models;

namespace TrailerOrder.Repositories
{
    public interface ITrailerRepository
    {
        List<Trailer> GetAvailableTrailers();
        Trailer GetTrailerWithId(int id);
    }
}