using System.Collections.Generic;
using TrailerOrder.Models;

namespace TrailerOrder.Repositories
{
    public interface ITractorRepository
    {
        Tractor Add(Tractor tractor);
        Tractor ChangeStatusWithId(int id);
        Tractor Edit(Tractor tractor);
        List<Tractor> GetAllTractor();
        List<Tractor> GetAvailableTractor();
        Tractor GetTractorWithId(int id);
        bool Remove(int tractorId);
        bool Remove(int[] tractorIds);
    }
}