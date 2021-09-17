using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommunalServices.Model.Entities
{
    /// <summary>Вид услуги</summary>
    public class ServiceType
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Наименование типа услуги не может быть пустым.")]
        [StringLength(100)]
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        [Display(Name = "Расчет по площади")]
        public bool AreaCalc { get; set; }
        [Display(Name = "Единица измерения")]
        public int MeasureId { get; set; }
        public Measure Measure { get; set; }
        public List<ServiceHouse> ServiceHouses { get; set; }
        public List<RegistrationValue> RegistrationValues { get; set; }
        public List<ServiceProvider> ServiceProviders { get; set; }
        public List<Tariff> Tariffs { get; set; }
    }
}
