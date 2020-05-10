using ElasticMicroRabbitMQ.Domain.Core.Bus;
using ElasticMicroRabbitMQ.Transfer.Domain.Events;
using ElasticMicroRabbitMQ.Transfer.Domain.Interfaces;
using System.Threading.Tasks;

namespace ElasticMicroRabbitMQ.Transfer.Domain.EventHandlers
{
    public class TransferDeleteEmployeeEventHandler : IEventHandler<DeleteEmployeeEvent>
    {
        private readonly IEmployeeTransferRepository _enployeeTransferRepository;
        public TransferDeleteEmployeeEventHandler(IEmployeeTransferRepository enployeeTransferRepository)
        {
            _enployeeTransferRepository = enployeeTransferRepository;
        }
        public Task Handle(DeleteEmployeeEvent @event)
        {
            _enployeeTransferRepository.TransferDeleteEmployee(@event.Id);
            return Task.CompletedTask;
        }
    }
}
