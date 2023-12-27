using Microservice.VehicleApi.Infraestructure.Context.SeedData;
using Microservice.VehicleApi.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservice.VehicleApi.Infraestructure.Context
{
    public class DBContext : DbContext
	{
		public DBContext(DbContextOptions<DBContext> options) : base(options)
		{

		}

		public DbSet<VehicleType> VehicleTypes { get; set; }
		public DbSet<Vehicle> Vehicles { get; set; }
		public DbSet<Configuration> Configurations { get; set; }
		public DbSet<MaintenanceElement> MaintenanceElement { get; set; }
		public DbSet<Operation> Operation { get; set; }
		public DbSet<OperationType> OperationType { get; set; }
		public DbSet<OperationMaintenanceElement> OperationMaintenanceElement { get; set; }

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
