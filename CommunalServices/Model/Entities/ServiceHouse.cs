using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunalServices.Model.Entities
{
    /// <summary>Услуга по дому</summary>
    public class ServiceHouse
    {
        public int Id { get; set; }
        public int ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }
        public int HouseId { get; set; }
        public House House { get; set; }
        public DateTime StartDate { get; set; }
    }
}
