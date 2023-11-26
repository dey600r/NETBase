using AutoMapper;
using BASE.AppInfrastructure.Entities;
using BASE.Common.Dtos;

namespace BASE.AppCore.Mappers
{
    public class BusinessProfile : Profile
	{
		public BusinessProfile() { 
			CreateMap<Vehicle, VehicleModel>()
				.ReverseMap().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
			//CreateMap<VehicleModel, Vehicle>().ForMember(nameof(Vehicle.IdConfiguration), (dest) => dest))
			CreateMap<VehicleType, VehicleTypeModel>()
				.ReverseMap().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
		}
	}
}
