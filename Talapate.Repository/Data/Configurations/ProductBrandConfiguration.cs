using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talapate.Core.Entities;

namespace Talapate.Repository.Data.Configurations
{
    public class ProductBrandConfiguration : IEntityTypeConfiguration<productBrand>
    {
        public void Configure(EntityTypeBuilder<productBrand> builder)
        {
            builder.Property(b => b.Name)
                .HasMaxLength(100);
        }
    }
}
