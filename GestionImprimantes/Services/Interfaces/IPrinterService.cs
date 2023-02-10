using GestionImprimantes.Models;

namespace GestionImprimantes.Services.Interfaces
{
    public interface IPrinterService
    {


        bool AddUpdate(Printer printer);



        string Delete(Printer printer);


        Printer FindById(int id);


        List<Printer> GetAll();
    }
}
