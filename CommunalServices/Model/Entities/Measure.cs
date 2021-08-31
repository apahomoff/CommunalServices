using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunalServices.Model.Entities
{
    /// <summary>Единица измерения</summary>
    public class Measure
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ServiceType> ServiceTypes { get; set; }
    }
}
