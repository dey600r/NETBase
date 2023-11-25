﻿using BASE.AppInfrastructure.Context;
using BASE.AppInfrastructure.Entities;

namespace BASE.AppInfrastructure.Repository
{
	public class VehicleRepository : BaseRepository<VehicleType, int>, IVehicleRepository
	{
		public VehicleRepository(DBContext dbContext) : base(dbContext)
		{
		}
	}
}