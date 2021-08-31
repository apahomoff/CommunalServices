using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunalServices.Model.Entities
{
    /// <summary>Поставщик услуг</summary>
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ServiceProvider> ServiceProviders { get; set; }
    }
}
