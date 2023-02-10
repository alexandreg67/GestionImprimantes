using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace GestionImprimantes.Models
{
    public class Location : Common
    {
        

        public string? Adresse { get; set; }


        [Required]
        public string? Ville { get; set; }



        public string? CodePostal { get; set; }



        public ICollection<Printer>? Printers { get; set;} = new List<Printer>();
    }
}
