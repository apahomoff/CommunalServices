using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunalServices.Model.Entities
{
    /// <summary>Дом</summary>
    public class House
    {
        public int Id { get; set; }
        public int StreetId { get; set; }
        public Street Street { get; set; }
        public string Number { get; set; }
        public float AreaLiving { get; set; }
        public float AreaMOP { get; set; }
        public List<Apartment> Apartments { get; set; }
        public List<ServiceHouse> ServiceHouses { get; set; }
    }
}
