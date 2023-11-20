using System.ComponentModel.DataAnnotations;

namespace ahmedHanen.Models
{
    public class Membre
    {
        [Key]
        [Required(ErrorMessage = "Le champ Nom est obligatoire.")]
        public string Nom { get; set; }

        [Range(1, 90, ErrorMessage = "L'âge doit être compris entre 1 et 120.")]
        [Required(ErrorMessage = "Le champ Âge est obligatoire.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Le champ Adresse E-mail est obligatoire.")]
        public string AddrMail { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$",
    ErrorMessage = "Le mot de passe doit contenir au moins une lettre majuscule, une lettre minuscule et un chiffre.")]
        public string MotDePasse { get; set; }

        [RegularExpression("^(homme|femme)$", ErrorMessage = "Le sexe doit être 'homme' ou 'femme'.")]
        [Required(ErrorMessage = "Le champ Sexe est obligatoire.")]
        public string Sexe { get; set; }
    }
}
