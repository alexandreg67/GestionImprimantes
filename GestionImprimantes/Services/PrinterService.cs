using GestionImprimantes.Data;
using GestionImprimantes.Models;
using GestionImprimantes.Services.Interfaces;

namespace GestionImprimantes.Services
{
    public class PrinterService : IPrinterService
    {

        private readonly DataBaseContext _context;


        public PrinterService(DataBaseContext context)
        {
            _context = context;
        }



        public bool AddUpdate(Printer printer)
        {

            if (string.IsNullOrEmpty(printer.Nom))
            {
                throw new Exception("Il faut un nom!");
            }

            if (printer.Id == 0)
            {
                _context.Printers.Add(printer);
            }
            else
            {
                _context.Printers.Update(printer);
            }
            _context.SaveChangesAsync();
            return true;
        }



        public string Delete(Printer printer)
        {
            try
            {
                printer.DateDeSuppression = DateTime.Now;
                _context.SaveChangesAsync();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Printer FindById(int id)
        {
            return _context.Printers.Find(id);
        }

        public List<Printer> GetAll()
        {
            return _context.Printers.ToList();
        }

    }
}
