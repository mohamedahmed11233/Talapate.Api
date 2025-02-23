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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Discription)
                .IsRequired();

            builder.Property(builder => builder.PictureUrl)
                .IsRequired();
            builder.Property(p => p.Price)
            .HasColumnType("decimal(18,2)");
            builder.HasOne(p => p.Brand)
                .WithMany()
                .HasForeignKey(p => p.BrandId);

            builder.HasOne(p => p.Cataegory)
                .WithMany()
                .HasForeignKey(p => p.CataegoryId);
        }
    }
}
