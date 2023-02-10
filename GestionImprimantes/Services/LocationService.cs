using GestionImprimantes.Data;
using GestionImprimantes.Models;
using GestionImprimantes.Pages.Location;
using GestionImprimantes.Services.Interfaces;
using MudBlazor;
using System.Collections.Generic;

namespace GestionImprimantes.Services
{
    public class LocationService : ILocationService
    {

        private readonly DataBaseContext _context;


        public LocationService(DataBaseContext context) 
        {
            _context = context;
        }


        public bool AddUpdate(Location location)
        {
            location.Ville = location.Ville.ToUpper();
            if (location.Id == 0)
            {
                _context.Locations.Add(location);
            }
            else
            {
                _context.Locations.Update(location);
            }
            _context.SaveChangesAsync();
            return true;
        }



        //public string Delete(Location location)
        //{
        //    if ()
        //    try
        //    {
        //        location.DateDeSuppression = DateTime.Now;
        //        _context.SaveChangesAsync();
        //        return "";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.ToString();
        //    }

        //}
  

        public string Delete(Location location) 
        {
            try
            {
                if (_context.Printers.Any(x => x.LocationId == location.Id))
                {
                    var printerLocation = _context.Printers.Where(x => x.LocationId == location.Id).ToList();
                    foreach (var printer in printerLocation)
                    {
                        printer.DateDeSuppression = DateTime.Now;
                    }
                }

                location.DateDeSuppression = DateTime.Now;

                _context.SaveChangesAsync();
                return "";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            
        }

        public Location FindById(int id)
        {
            return _context.Locations.Find(id);
        }


        public List<Location> GetAll()
        {
            return _context.Locations.ToList();
        }
    }
}
