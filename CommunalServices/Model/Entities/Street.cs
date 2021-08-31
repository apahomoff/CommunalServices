using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunalServices.Model.Entities
{
    /// <summary>Улица</summary>
    public class Street
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<House> Houses { get; set; }
    }
}
