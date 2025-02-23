using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talapate.Core.Entities;

namespace Talapate.Repository.Data.Configurations
{
    internal class ProductCataguryConfiguration : IEntityTypeConfiguration<ProductCataegory>
    {
        public void Configure(EntityTypeBuilder<ProductCataegory> builder)
        {
            builder.Property(b => b.Name)
                .IsRequired();
        }

    }
}
