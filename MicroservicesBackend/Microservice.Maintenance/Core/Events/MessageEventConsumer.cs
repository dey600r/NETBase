using AutoMapper;
using MassTransit;
using Microservice.Core.Events;
using Microservice.MaintenanceApi.Infraestructure.Entities;
using Microservice.MaintenanceApi.Infraestructure.Repository;

namespace Microservice.MaintenanceApi.Core.Events
{
	public class MessageEventConsumer : IConsumer<MessageConfigurationEvent>
	{
		private readonly IConfigurationRepository _configurationRepository;
		private readonly ILogger<MessageEventConsumer> _logger;
		private readonly IMapper _mapper;

		public MessageEventConsumer(IConfigurationRepository configuration, ILogger<MessageEventConsumer> logger, IMapper mapper) 
		{
			_configurationRepository = configuration;
			_logger = logger;
			_mapper = mapper;
		}

		public Task Consume(ConsumeContext<MessageConfigurationEvent> context)
		{
			_logger.LogInformation("Consuming message configuration");
			_configurationRepository.Add(_mapper.Map<Configuration>(context.Message));
			return Task.CompletedTask;
		}
	}
}
