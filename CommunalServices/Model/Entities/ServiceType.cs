using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunalServices.Model.Entities
{
    /// <summary>Вид услуги</summary>
    public class ServiceType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool AreaCalc { get; set; }
        public int MeasureId { get; set; }
        public Measure Measure { get; set; }
        public List<ServiceHouse> ServiceHouses { get; set; }
        public List<RegistrationValue> RegistrationValues { get; set; }
        public List<ServiceProvider> ServiceProviders { get; set; }
        public List<Tariff> Tariffs { get; set; }
    }
}
