using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pathfinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pathfinder.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(p => p.Title)
                .HasColumnName("Title")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(p => p.Description)
               .HasColumnName("Description")
               .HasColumnType("varchar(150)")
               .IsRequired();

            builder.Property(p => p.Price)
               .HasColumnName("Price")
               .HasColumnType("money")
               .IsRequired();

            builder.Property(p => p.Image)
               .HasColumnName("Image")
               .HasColumnType("varchar(50)")
               .IsRequired();

            builder.Property(p => p.CategoryId)
                .HasColumnName("CategoryId")
                .IsRequired();

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .IsRequired();
        }
    }
}
