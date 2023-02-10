using System;
using System.ComponentModel.DataAnnotations;

namespace GestionImprimantes.Models
{
    public class Common
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Il faut un nom")]
        public string Nom { get; set; }


        public DateTime DateDeModification { get; set; } = default(DateTime);


        public DateTime DateDeCreation { get; set; }


        public DateTime? DateDeSuppression { get; set; } = null;
    }
}
