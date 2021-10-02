using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunalServices.Model.Entities
{
    /// <summary>Квартира</summary>
    public class Apartment
    {
        public int Id { get; set; }
        public int HouseId { get; set; }
        public House House { get; set; }
        public int Number { get; set; }
        public float? Area { get; set; }
        public DateTime? DateReg { get; set; }
        public List<RegistrationValue> RegistrationValues { get; set; }
    }
}
