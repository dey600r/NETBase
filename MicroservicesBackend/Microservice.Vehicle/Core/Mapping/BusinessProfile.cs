using AutoMapper;
using Microservice.Core.Events;
using Microservice.VehicleApi.Core.Dtos;
using Microservice.VehicleApi.Infraestructure.Entities;

namespace Microservice.VehicleApi.Core.Mapping
{
    public class BusinessProfile : Profile
	{
		public BusinessProfile()
		{
			CreateMap<Vehicle, VehicleModel>()
				.ReverseMap().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
			CreateMap<VehicleModel, Vehicle>()
				.ForPath(dest => dest.Configuration, opt => opt.MapFrom(src => new Configuration() { Id = src.ConfigurationId }))
				.ForPath(dest => dest.VehicleType, opt => opt.MapFrom(src => new VehicleType() { Id = src.VehicleTypeId }));
			CreateMap<VehicleType, VehicleTypeModel>()
				.ReverseMap().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
			CreateMap<Configuration, ConfigurationModel>()
				.ReverseMap().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

			CreateMap<Configuration, MessageConfigurationEvent>();
		}
	}
}
