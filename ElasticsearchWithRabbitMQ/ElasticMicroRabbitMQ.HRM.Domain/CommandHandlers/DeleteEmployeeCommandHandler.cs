using MediatR;
using ElasticMicroRabbitMQ.Domain.Core.Bus;
using ElasticMicroRabbitMQ.HRM.Domain.Commands;
using ElasticMicroRabbitMQ.HRM.Domain.Events;
using System.Threading;
using System.Threading.Tasks;

namespace ElasticMicroRabbitMQ.HRM.Domain.CommandHandlers
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IEventBus _bus;

        public DeleteEmployeeCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }
        public Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            //Publish event to RabbitMQ
            _bus.Publish(new DeleteEmployeeEvent(request.Id));

            return Task.FromResult(true);
        }
    }
}
