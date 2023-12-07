using AutoMapper;
using Microservice.Security.Core.Application.Dto;
using Microservice.Security.Core.Persistence.Entities;

namespace Microservice.Security.Core.Application.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<User, UserDto>();
		}
	}
}
