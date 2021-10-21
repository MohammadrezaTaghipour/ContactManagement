using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Peekage.ContactManagement.Service.Framework
{
    public interface ICommandBus
    {
        Task Dispatch<T>(T command);
    }

    public class CommandBus : ICommandBus
    {
        IServiceProvider _serviceProvider;
        ILogger<CommandBus> _logger;

        public CommandBus(IServiceProvider serviceProvider,
            ILogger<CommandBus> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task Dispatch<T>(T command)
        {
            _logger.LogInformation($"Starting handling command of type: {command.GetType().Name}.");
            var handler = (ICommandHandler<T>)_serviceProvider.GetService(typeof(ICommandHandler<T>));
            await handler.Handle(command);
            _logger.LogInformation($"Handling command of type: {command.GetType().Name} finished successfully");
        }
    }
}
