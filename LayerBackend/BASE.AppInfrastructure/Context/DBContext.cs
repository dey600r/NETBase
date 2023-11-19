using BASE.AppInfrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BASE.AppInfrastructure.Context
{
	public class DBContext : DbContext
	{
		public DBContext(DbContextOptions<DBContext> options) : base(options)
		{

		}

		public DbSet<VehicleType> VehicleTypes { get; set; }
		public DbSet<Vehicle> Vehicles { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			
			//optionsBuilder.EnableSensitiveDataLogging().UseSqlServer(@"Server=(localdb)\\mssqllocaldb;Database=BaseDB;Trusted_Connection=True;");
			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			//modelBuilder.Entity<VehicleType>();
			//modelBuilder.Entity<Vehicle>();
		}
	}
}
