using GCScript_Tools_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCScript_Tools_API.Data.Mappings;

public class UnitMap : IEntityTypeConfiguration<Unit>
{
    public void Configure(EntityTypeBuilder<Unit> builder)
    {
        builder.ToTable("Unit");

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

        builder.Property(x => x.Login)
               .IsRequired()
               .HasColumnName("Login")
               .HasMaxLength(100)
               .HasColumnType("nvarchar")
               .HasColumnOrder(3);

        builder.Property(x => x.Password)
               .IsRequired()
               .HasColumnName("Password")
               .HasMaxLength(64)
               .HasColumnType("nvarchar")
               .HasColumnOrder(4);

        builder.Property(x => x.CNPJ)
               .IsRequired()
               .HasColumnName("CNPJ")
               .HasMaxLength(14)
               .HasColumnType("varchar")
               .HasColumnOrder(5);

        builder.Property(x => x.Registered)
               .IsRequired()
               .HasColumnName("Registered")
               .HasPrecision(6)
               .HasColumnOrder(6);

        builder.Property(x => x.CompanyId)
               .IsRequired()
               .HasColumnName("CompanyId");

        builder.Property(x => x.OperatorId)
               .IsRequired()
               .HasColumnName("OperatorId");

        builder.HasIndex(x => new { x.Slug, x.CompanyId, x.OperatorId }, "IX_Unit_Slug_Company_Operator")
               .IsUnique();

        builder.HasOne(x => x.Company)
               .WithMany(x => x.Units)
               .HasForeignKey(x => x.CompanyId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Operator)
               .WithMany(x => x.Units)
               .HasForeignKey(x => x.OperatorId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
