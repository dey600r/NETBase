using AutoMapper;
using BASE.AppInfrastructure.Entities.Core;
using BASE.AppInfrastructure.Entities.Security;
using BASE.Common.Dtos;
using BASE.Common.Dtos.Security;

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

			// SECURITY
			CreateMap<User, UserModel>()
				.ReverseMap().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
		}
	}
}
