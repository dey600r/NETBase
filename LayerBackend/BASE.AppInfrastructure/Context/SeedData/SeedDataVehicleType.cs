﻿using BASE.AppInfrastructure.Entities;
using BASE.Common.Constants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BASE.AppInfrastructure.Context.SeedData
{
	public static class SeedDataVehicleType
	{
		public static void Seed( ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<VehicleType>().HasData(new VehicleType 
				{ Id = 1, Code = Constants.VEHICLE_TYPE_CODE_MOTO, Description = Constants.VEHICLE_TYPE_DESCRIPTION_MOTO });
			modelBuilder.Entity<VehicleType>().HasData(new VehicleType
				{ Id = 2, Code = Constants.VEHICLE_TYPE_CODE_CAR, Description = Constants.VEHICLE_TYPE_DESCRIPTION_CAR });
			modelBuilder.Entity<VehicleType>().HasData(new VehicleType
				{ Id = 3, Code = Constants.VEHICLE_TYPE_CODE_OTHER, Description = Constants.VEHICLE_TYPE_DESCRIPTION_OTHER });
		}
	}
}