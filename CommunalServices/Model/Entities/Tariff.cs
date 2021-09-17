using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommunalServices.Model.Entities
{
    /// <summary>Тариф</summary>
    public class Tariff
    {
        public int Id { get; set; }
        public int ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }
        [Required(ErrorMessage = "Значение не может быть пустым.")]
        [Display(Name = "Значение")]
        public float Value { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Дата начала не может быть пустой.")]
        [Display(Name = "Дата начала")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Дата окончания")]
        public DateTime? FinishDate { get; set; }
    }
}
