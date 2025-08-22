using AutoMapper;
using Microservice.Core.Events;
using Microservice.MaintenanceApi.Core.Dtos;
using Microservice.MaintenanceApi.Infraestructure.Entities;
using Microservice.VehicleApi.Core.Dtos.Events;

namespace Microservice.MaintenanceApi.Core.Mapping
{
    public class BusinessProfile : Profile
	{
		public BusinessProfile()
		{
			CreateMap<Configuration, ConfigurationModel>()
				.ReverseMap().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
			CreateMap<MaintenanceElement, MaintenanceElementModel>()
				.ReverseMap().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

			CreateMap<MessageConfigurationEvent, Configuration>();
			CreateMap<MaintenanceElement, MessageMaintenanceElementEvent>();
		}
	}
}
