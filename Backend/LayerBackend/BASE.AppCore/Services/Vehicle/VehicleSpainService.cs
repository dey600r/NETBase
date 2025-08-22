﻿
using AutoMapper;
using BASE.AppInfrastructure.Entities.Core;
using BASE.AppInfrastructure.Repository;
using BASE.Common.Dtos;

namespace BASE.AppCore.Services
{
    public class VehicleSpainService : BaseService<VehicleModel, Vehicle, int>, IVehicleSpainService
	{
		public VehicleSpainService(IVehicleRepository vehicleRepository, IMapper mapper) : base(mapper, vehicleRepository)
		{
		}

		public IEnumerable<VehicleModel> GetVehicles() {

            //var results = _baseRepository.Add(new List<Vehicle>()
            //{
            //	new Vehicle
            //	{
            //		Brand = "Yamaha",
            //		Model = "R6",
            //		Km = 100000,
            //		Year = 2006,
            //		DateKms = DateTime.UtcNow,
            //		KmsPerMonth = 600,
            //		Active = true,
            //		VehicleTypeId = 1,
            //		//VehicleType = new VehicleType() { Id = 1 },
            //		ConfigurationId = 1,
            //		//Configuration = new Configuration() { Id = 1 }
            //	},
            //	new Vehicle
            //	{
            //		Brand = "Kawasaki",
            //		Model = "Ninja 1000 sx",
            //		Km = 30000,
            //		Year = 2021,
            //		DateKms = DateTime.UtcNow,
            //		KmsPerMonth = 600,
            //		Active = true,
            //		VehicleTypeId = 1,
            //		//VehicleType = new VehicleType() { Id = 1 },
            //		ConfigurationId = 1,
            //		//Configuration = new Configuration() { Id = 1 }
            //	}
            //});

            IEnumerable<VehicleModel> results = GetAll(x => x.Brand == "Yamaha" || x.Brand == "Kawasaki").ToList();

            //IEnumerable<Vehicle> results = _baseRepository.GetAll(x => x.Brand == "Yamaha" || x.Brand == "Kawasaki").ToList();

            results.ElementAt(0).Brand = "Honda";
            results.ElementAt(0).Brand = "Triumph";

            //results = _baseRepository.Update(results);

            return Update(results);

			//return results.Select(x => _mapper.Map<VehicleModel>(x)).ToList();

            //return _baseRepository.GetAll(x => x.Brand == "Yamaha").Select(x => _mapper.Map<VehicleModel>(x)).ToList();
		}
	}
}
