using CommunalServices.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunalServices.Model.EF.EntitiesConfiguration
{
    public class HouseConfiguration : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder.Property(p => p.Number).IsRequired().HasMaxLength(10);
            builder.HasAlternateKey(h => new { h.StreetId, h.Number });
        }
    }
}
