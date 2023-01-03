using GCScript_Tools_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCScript_Tools_API.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Username)
           .IsRequired()
           .HasColumnName("Username")
           .HasMaxLength(18)
           .HasColumnType("varchar");

        builder.Property(x => x.Password)
               .IsRequired()
               .HasColumnName("Password")
               .HasMaxLength(18)
               .HasColumnType("nvarchar");

        builder.Property(x => x.Name)
               .IsRequired()
               .HasColumnName("Name")
               .HasMaxLength(50)
               .HasColumnType("varchar");

        builder.Property(x => x.Phone)
               .IsRequired()
               .HasColumnName("Phone")
               .HasMaxLength(11)
               .HasColumnType("varchar");

        builder.Property(x => x.Email)
               .IsRequired()
               .HasColumnName("Email")
               .HasMaxLength(256)
               .HasColumnType("varchar");

        builder.Property(x => x.Registered)
               .IsRequired()
               .HasColumnName("Registered")
               .HasPrecision(6);

        builder.HasIndex(x => x.Username, "IX_User_Username").IsUnique();

        builder.HasOne(x => x.Role)
               .WithMany(x => x.Users)
               .HasForeignKey(x => x.RoleId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(new User()
        {
            Id = Guid.Parse("74cfc33f-714f-4f3b-85a8-f338820381b4"),
            Username = "gcs5stars",
            Password = "157131413",
            Name = "Gustavo",
            Email = "gcs5stars@gmail.com",
            Phone = "21966473139",
            RoleId = Guid.Parse("68D40C73-5600-4530-A62F-ACE53D271AB8")
        },
        new User()
        {
            Id = Guid.Parse("bc651730-bfc9-41f9-96bd-0d1fc6f7a17f"),
            Username = "lenane",
            Password = "157131413",
            Name = "Ellen",
            Email = "ellen.tatiane1905@gmail.com",
            Phone = "21989380770",
            RoleId = Guid.Parse("4A081992-A085-4AAD-BCFE-25605281E7BD")
        });
    }
}
