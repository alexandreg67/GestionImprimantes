using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionImprimantes.Models
{
    public class Printer : Common
    {

        public string? Marque { get; set; }


        public string? Modele { get; set; }


        public string? Serie { get; set; }


        public int? Encre { get; set; }


        [ForeignKey("LocationId")]
        public Location Location { get; set; } = null!;

        public int LocationId { get; set; } 
    }
}
