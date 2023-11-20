using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ahmedHanen.Models
{
    public class Admin
    {
        [Key]
        [Required(ErrorMessage = "Le champ Nom est obligatoire.")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le champ Prénom est obligatoire.")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Le champ Email est obligatoire.")]
        [EmailAddress(ErrorMessage = "L'adresse e-mail n'est pas valide.")]
        [RegularExpression(@"^.*@(gmail\.com|gmail\.fr)$", ErrorMessage = "L'adresse e-mail doit se terminer par @gmail.com ou @gmail.fr.")]
        public string Email { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$",
    ErrorMessage = "Le mot de passe doit contenir au moins une lettre majuscule, une lettre minuscule et un chiffre.")]
        public string MotDePasse { get; set; }
    }
}
