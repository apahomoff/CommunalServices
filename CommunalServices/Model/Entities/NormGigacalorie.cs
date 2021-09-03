using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CommunalServices.Model.Entities
{
    /// <summary>Норматив гигакалорий</summary>
    public class NormGigacalorie
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Значение не может быть пустым.")]
        [Display(Name = "Значение")]
        public float Value { get; set; }
        [Required(ErrorMessage = "Год не может быть пустым.")]
        [Display(Name = "Год")]
        public int Year { get; set; }
    }
}
