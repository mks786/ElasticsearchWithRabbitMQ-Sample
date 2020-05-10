using ElasticMicroRabbitMQ.Common.Model;
using ElasticMicroRabbitMQ.Domain.Core.Bus;
using ElasticMicroRabbitMQ.Transfer.Domain.Events;
using ElasticMicroRabbitMQ.Transfer.Domain.Interfaces;
using System.Threading.Tasks;

namespace ElasticMicroRabbitMQ.Transfer.Domain.EventHandlers
{
    public class TransferNewEmployeeEventHandler : IEventHandler<NewEmployeeCreatedEvent>
    {
        private readonly IEmployeeTransferRepository _enployeeTransferRepository;
        public TransferNewEmployeeEventHandler(IEmployeeTransferRepository enployeeTransferRepository)
        {
            _enployeeTransferRepository = enployeeTransferRepository;
        }
        public Task Handle(NewEmployeeCreatedEvent @event)
        {
            _enployeeTransferRepository.TransferInsertEmployee(new Employee()
            {
                Id = @event.Id,
                FirstName = @event.FirstName,
                LastName = @event.LastName,
                Age = @event.Age,
                Salary = @event.Salary,
            });
            return Task.CompletedTask;
        }
    }
}
