using BASE.AppInfrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BASE.AppInfrastructure.Context.Configurations
{
	public class ConfigurationConfiguration
	{
		public void Configure(EntityTypeBuilder<Configuration> builder)
		{
			builder.Property(b => b.Name).IsRequired();
			builder.Property(b => b.Description).IsRequired();
			builder.Property(b => b.Master).IsRequired().HasDefaultValue(false);
		}
	}
}
