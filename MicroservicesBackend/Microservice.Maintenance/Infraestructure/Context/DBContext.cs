using Microservice.MaintenanceApi.Infraestructure.Context.SeedData;
using Microservice.MaintenanceApi.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservice.MaintenanceApi.Infraestructure.Context
{
    public class DBContext : DbContext
	{
		public DBContext(DbContextOptions<DBContext> options) : base(options)
		{

		}

		public DbSet<Configuration> Configurations { get; set; }
		public DbSet<ConfigurationMaintenance> ConfigurationMaintenance { get; set; }
		public DbSet<Maintenance> Maintenance { get; set; }
		public DbSet<MaintenanceElement> MaintenanceElement { get; set; }
		public DbSet<MaintenanceFreq> MaintenanceFreq { get; set; }
		public DbSet<MaintenanceMaintenanceElement> MaintenanceMaintenanceElement { get; set; }

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
