using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommunalServices.Model.Entities
{
    /// <summary>Поставщик услуг</summary>
    public class Provider
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Наименование поставщика не может быть пустым.")]
        [StringLength(100)]
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        public List<ServiceProvider> ServiceProviders { get; set; }
    }
}
