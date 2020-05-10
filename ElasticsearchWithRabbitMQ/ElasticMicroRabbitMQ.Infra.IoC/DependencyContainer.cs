using ElasticMicroRabbitMQ.Domain.Core.Bus;
using ElasticMicroRabbitMQ.Infra.Bus;
using ElasticMicroRabbitMQ.Transfer.Domain.Events;
using MediatR;
using ElasticMicroRabbitMQ.Transfer.Domain.EventHandlers;
using Microsoft.Extensions.DependencyInjection;
using ElasticMicroRabbitMQ.HRM.Domain.Commands;
using ElasticMicroRabbitMQ.HRM.Domain.CommandHandlers;
using ElasticMicroRabbitMQ.HRM.Application.Interfaces;
using ElasticMicroRabbitMQ.HRM.Application.Services;
using ElasticMicroRabbitMQ.Transfer.Domain.Interfaces;
using ElasticMicroRabbitMQ.Transfer.Domain.Repositories;
using ElasticMicroRabbitMQ.HRM.Domain.Repositories;
using ElasticMicroRabbitMQ.HRM.Domain.Interfaces;

namespace ElasticMicroRabbitMQ.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopFactory);
            });

            //Subscriptions
            services.AddTransient<TransferNewEmployeeEventHandler>();
            services.AddTransient<TransferUpdateEmployeeEventHandler>();
            services.AddTransient<TransferDeleteEmployeeEventHandler>();

            //Domain Events
            services.AddTransient<IEventHandler<NewEmployeeCreatedEvent>, TransferNewEmployeeEventHandler>();
            services.AddTransient<IEventHandler<UpdateEmployeeEvent>, TransferUpdateEmployeeEventHandler>();
            services.AddTransient<IEventHandler<DeleteEmployeeEvent>, TransferDeleteEmployeeEventHandler>();

            //Domain Employee Command
            services.AddTransient<IRequestHandler<CreateNewEmployeeCommand, bool>, NewEmployeeCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateEmployeeCommand, bool>, UpdateEmployeeCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteEmployeeCommand, bool>, DeleteEmployeeCommandHandler>();

            // Application Services            
            services.AddTransient<IEmployeeService, EmployeeService>();            
            services.AddTransient<IEmployeeTransferRepository, EmployeeTransferRepository>();            
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();            
        }
    }
}
