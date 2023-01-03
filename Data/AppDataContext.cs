using GCScript_Tools_API.Data.Mappings;
using GCScript_Tools_API.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GCScript_Tools_API.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) { }

        public DbSet<Company>? Companies { get; set; }
        public DbSet<Operator>? Operators { get; set; }
        public DbSet<Role>? Roles { get; set; }
        public DbSet<Unit>? Units { get; set; }
        public DbSet<User>? Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyMap());
            modelBuilder.ApplyConfiguration(new OperatorMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UnitMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}
