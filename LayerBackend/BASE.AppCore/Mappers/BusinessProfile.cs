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
			CreateMap<VehicleModel, Vehicle>()
				.ForPath(dest => dest.Configuration, opt => opt.MapFrom(src => new Configuration() { Id = src.IdConfiguration }))
				.ForPath(dest => dest.VehicleType, opt => opt.MapFrom(src => new VehicleType() { Id = src.IdVehicleType }));
			CreateMap<VehicleType, VehicleTypeModel>()
				.ReverseMap().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
		}
	}
}
