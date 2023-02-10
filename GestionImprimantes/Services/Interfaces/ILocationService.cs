using GestionImprimantes.Models;

namespace GestionImprimantes.Services.Interfaces
{
    public interface ILocationService
    {

        bool AddUpdate(Location location);


        public string Delete(Location location);


        Location FindById(int id);


        List<Location> GetAll();
    }
}