using Domain.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data.Configurations
{
    internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");
            builder.Property(d => d.Price).HasColumnType("decimal(8,2)");

            // العلاقة مع Order
            builder.HasOne(oi => oi.Order)
                   .WithMany(o => o.Items)
                   .HasForeignKey(oi => oi.OrderId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired();

            // Owned Entity
            builder.OwnsOne(oi => oi.Product, p =>
            {
                p.Property(pp => pp.ProductName).HasColumnType("nvarchar(100)");
                p.Property(pp => pp.PictureUrl).HasColumnType("nvarchar(200)");
            });
        }
    }
}