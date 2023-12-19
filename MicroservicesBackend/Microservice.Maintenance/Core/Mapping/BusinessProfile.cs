using AutoMapper;
using Microservice.MaintenanceApi.Core.Dtos;
using Microservice.MaintenanceApi.Infraestructure.Entities;

namespace Microservice.MaintenanceApi.Core.Mapping
{
    public class BusinessProfile : Profile
	{
		public BusinessProfile()
		{
			CreateMap<Configuration, ConfigurationModel>()
				.ReverseMap().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
		}
	}
}
