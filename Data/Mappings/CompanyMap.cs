using GCScript_Tools_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCScript_Tools_API.Data.Mappings;

public class CompanyMap : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Company");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .IsRequired()
               .HasColumnName("Id")
               .HasColumnOrder(0);

        builder.Property(x => x.Slug)
               .IsRequired()
               .HasColumnName("Slug")
               .HasMaxLength(100)
               .HasColumnType("varchar")
               .HasColumnOrder(1);

        builder.Property(x => x.Name)
               .IsRequired()
               .HasColumnName("Name")
               .HasMaxLength(100)
               .HasColumnType("varchar")
               .HasColumnOrder(2);

        builder.Property(x => x.PurchaseMargin)
               .IsRequired()
               .HasColumnName("PurchaseMargin")
               .HasColumnType("tinyint")
               .HasColumnOrder(3);

        builder.Property(x => x.Registered)
               .IsRequired()
               .HasColumnName("Registered")
               .HasPrecision(6)
               .HasColumnOrder(4);

        builder.HasIndex(x => x.Slug, "IX_Company_Slug").IsUnique();

        builder.HasOne(x => x.Responsible)
               .WithMany(x => x.CompanyResponsibles)
               .HasForeignKey(x => x.ResponsibleId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
