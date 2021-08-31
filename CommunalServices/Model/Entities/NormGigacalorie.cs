using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunalServices.Model.Entities
{
    /// <summary>Норматив гигакалорий</summary>
    public class NormGigacalorie
    {
        public int Id { get; set; }
        public float Value { get; set; }
        public int Year { get; set; }
    }
}
