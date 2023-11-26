using AutoMapper;
using BASE.AppInfrastructure.Entities;
using BASE.Common.Dtos.Vehicle;

namespace BASE.AppCore.Mappers
{
    public class BusinessProfile : Profile
	{
		public BusinessProfile() { 
			CreateMap<VehicleType, VehicleTypeModel>()
				.ReverseMap().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
			//CreateMap<Vehicle, VehicleModel>().ReverseMap();
		}
	}
}
