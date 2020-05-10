using MediatR;
using ElasticMicroRabbitMQ.Domain.Core.Bus;
using ElasticMicroRabbitMQ.HRM.Domain.Commands;
using ElasticMicroRabbitMQ.HRM.Domain.Events;
using System.Threading;
using System.Threading.Tasks;

namespace ElasticMicroRabbitMQ.HRM.Domain.CommandHandlers
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
    {
        private readonly IEventBus _bus;

        public UpdateEmployeeCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }
        public Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            //Publish event to RabbitMQ
            _bus.Publish(new UpdateEmployeeEvent(request.Id, request.FirstName, request.LastName, request.Age, request.Salary));

            return Task.FromResult(true);
        }
    }
}
