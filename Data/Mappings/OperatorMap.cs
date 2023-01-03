using GCScript_Tools_API.Models;
using GCScript_Tools_API.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCScript_Tools_API.Data.Mappings;

public class OperatorMap : IEntityTypeConfiguration<Operator>
{
    public void Configure(EntityTypeBuilder<Operator> builder)
    {
        builder.ToTable("Operator");

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

        builder.Property(x => x.UF)
               .IsRequired()
               .HasColumnName("UF")
               .HasMaxLength(2)
               .HasColumnType("char")
               .HasColumnOrder(3);

        builder.Property(x => x.Phone)
               .HasColumnName("Phone")
               .HasMaxLength(11)
               .HasColumnType("varchar")
               .HasColumnOrder(4);

        builder.Property(x => x.Email)
               .HasColumnName("Email")
               .HasMaxLength(254)
               .HasColumnType("varchar")
               .HasColumnOrder(5);

        builder.Property(x => x.Site)
               .IsRequired()
               .HasColumnName("Site")
               .HasMaxLength(500)
               .HasColumnType("varchar")
               .HasColumnOrder(6);

        builder.Property(x => x.Registered)
               .IsRequired()
               .HasColumnName("Registered")
               .HasPrecision(6)
               .HasColumnOrder(7);

        builder.HasIndex(x => x.Slug, "IX_Operator_Slug").IsUnique();
    }
}

public class CategoryPostViewModelMap : IEntityTypeConfiguration<OperatorPostViewModel>
{
    public void Configure(EntityTypeBuilder<OperatorPostViewModel> builder)
    {
        builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(x => x.UF)
               .IsRequired()
               .HasMaxLength(2);

        builder.Property(x => x.Phone)
               .HasMaxLength(11);

        builder.Property(x => x.Email)
               .HasMaxLength(254);

        builder.Property(x => x.Site)
               .IsRequired()
               .HasMaxLength(500);
    }
}

public class OperatorPutViewModelMap : IEntityTypeConfiguration<OperatorPutViewModel>
{
    public void Configure(EntityTypeBuilder<OperatorPutViewModel> builder)
    {
        builder.Property(x => x.Id)
               .IsRequired();

        builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(x => x.UF)
               .IsRequired()
               .HasMaxLength(2);

        builder.Property(x => x.Phone)
               .HasMaxLength(11);

        builder.Property(x => x.Email)
               .HasMaxLength(254);

        builder.Property(x => x.Site)
               .IsRequired()
               .HasMaxLength(500);
    }
}
