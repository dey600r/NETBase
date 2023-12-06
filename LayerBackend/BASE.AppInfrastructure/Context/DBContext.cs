using BASE.AppInfrastructure.Context.SeedData;
using BASE.AppInfrastructure.Entities.Core;
using BASE.AppInfrastructure.Entities.Security;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BASE.AppInfrastructure.Context
{
    public class DBContext : IdentityDbContext<User, Role, int>
	{
		public DBContext(DbContextOptions<DBContext> options) : base(options)
		{

		}

		public DbSet<VehicleType> VehicleTypes { get; set; }
		public DbSet<Vehicle> Vehicles { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			
			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Seed();
			base.OnModelCreating(modelBuilder);
		}
	}
}
