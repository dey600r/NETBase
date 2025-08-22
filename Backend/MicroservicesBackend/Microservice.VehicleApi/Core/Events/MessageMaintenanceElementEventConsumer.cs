using AutoMapper;
using MassTransit;
using Microservice.VehicleApi.Core.Dtos.Events;
using Microservice.VehicleApi.Infraestructure.Entities;
using Microservice.VehicleApi.Infraestructure.Repository;

namespace Microservice.VehicleApi.Core.Events
{
	public class MessageMaintenanceElementEventConsumer : IConsumer<MessageMaintenanceElementEvent>
	{
		private readonly IConfigurationRepository _configurationRepository;
		private readonly ILogger<MessageMaintenanceElementEventConsumer> _logger;
		private readonly IMapper _mapper;

		public MessageMaintenanceElementEventConsumer(IConfigurationRepository configuration, 
			ILogger<MessageMaintenanceElementEventConsumer> logger, IMapper mapper)
		{
			_configurationRepository = configuration;
			_logger = logger;
			_mapper = mapper;
		}

		public Task Consume(ConsumeContext<MessageMaintenanceElementEvent> context)
		{
			_logger.LogInformation("Consuming message maintenance element");
			_configurationRepository.Add(_mapper.Map<MaintenanceElement>(context.Message));
			return Task.CompletedTask;
		}
	}
}
