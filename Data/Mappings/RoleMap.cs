using GCScript_Tools_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCScript_Tools_API.Data.Mappings;

public class RoleMap : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Role");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
               .IsRequired()
               .HasColumnName("Name")
               .HasMaxLength(15)
               .HasColumnType("varchar");


        builder.HasIndex(x => x.Name, "IX_Role_Name").IsUnique();

        builder.HasData(new Role() { Id = Guid.Parse("68D40C73-5600-4530-A62F-ACE53D271AB8"), Name = "Developer" },
                             new Role() { Id = Guid.Parse("C2C444FB-CC88-4475-86DB-49FFC67EF5A1"), Name = "Administrator" },
                             new Role() { Id = Guid.Parse("4A081992-A085-4AAD-BCFE-25605281E7BD"), Name = "User Level 1" },
                             new Role() { Id = Guid.Parse("6F6E42A7-D33A-4F7E-BBF4-4B2E6450545E"), Name = "User Level 2" },
                             new Role() { Id = Guid.Parse("3403C3BE-3DDF-43D6-8C2A-C02ADDA47BE4"), Name = "User Level 3" });
    }
}
