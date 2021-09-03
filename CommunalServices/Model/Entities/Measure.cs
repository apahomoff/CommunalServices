using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommunalServices.Model.Entities
{
    /// <summary>Единица измерения</summary>
    public class Measure
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Наименование единицы измерения не может быть пустым.")]
        [StringLength(10)]
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        public List<ServiceType> ServiceTypes { get; set; }
    }
}
