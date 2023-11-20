using System;
using System.ComponentModel.DataAnnotations;

namespace ahmedHanen.Models
{
    public class Event
    {
        [Key]
        

        [Required(ErrorMessage = "Le champ Nom est obligatoire.")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le champ Date est obligatoire.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Le champ Lieu est obligatoire.")]
        public string Lieu { get; set; }

        [Required(ErrorMessage = "Le champ Description est obligatoire.")]
        [StringLength(100000, ErrorMessage = "La description ne peut pas dépasser 100 000 caractères.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Le champ Type est obligatoire.")]
        public string Type { get; set; }
    }
}
