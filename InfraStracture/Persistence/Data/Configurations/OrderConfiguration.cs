using Domain.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    internal class OrderConfiguration:IEntityTypeConfiguration<Order>
    {

public void Configure(EntityTypeBuilder<Order> builder)
{
    builder.ToTable("Orders");
    builder.Property(d => d.SubTotal).HasColumnType("decimal(8,2)");

    // العلاقة مع OrderItems
    builder.HasMany(o => o.Items)
           .WithOne(oi => oi.Order)
           .HasForeignKey(oi => oi.OrderId)
           .OnDelete(DeleteBehavior.Cascade);

    // العلاقة مع DeliveryMethod
    builder.HasOne(o => o.DeliveryMethod)
           .WithMany()
           .HasForeignKey(o => o.DeliveryMethodId)
           .OnDelete(DeleteBehavior.Restrict)
           .IsRequired();

    // Owned Entity
    builder.OwnsOne(o => o.Address, a => {
        a.Property(aa => aa.City).HasColumnType("nvarchar(50)");
        a.Property(aa => aa.Street).HasColumnType("nvarchar(100)");
        a.Property(aa => aa.Country).HasColumnType("nvarchar(50)");
        a.Property(aa => aa.FirstName).HasColumnType("nvarchar(50)");
        a.Property(aa => aa.LastName).HasColumnType("nvarchar(50)");
    });
        }
    }
}