using System.ComponentModel.DataAnnotations;

namespace GestionImprimantes.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Cp { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Prenom { get; set; }
    }
}
