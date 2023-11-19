using AutoMapper;
using BASE.AppInfrastructure.Entities;
using BASE.Common.Dtos;

namespace BASE.AppCore.Mappers
{
	public class BusinessProfile : Profile
	{
		public BusinessProfile() { 
			CreateMap<VehicleType, VehicleTypeModel>().ReverseMap();
			//CreateMap<Vehicle, VehicleModel>().ReverseMap();
		}
	}
}
