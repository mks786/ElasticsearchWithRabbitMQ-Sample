using ElasticMicroRabbitMQ.Common.Model;
using ElasticMicroRabbitMQ.Domain.Core.Bus;
using ElasticMicroRabbitMQ.Transfer.Domain.Events;
using ElasticMicroRabbitMQ.Transfer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElasticMicroRabbitMQ.Transfer.Domain.EventHandlers
{
    public class TransferUpdateEmployeeEventHandler : IEventHandler<UpdateEmployeeEvent>
    {
        private readonly IEmployeeTransferRepository _enployeeTransferRepository;
        public TransferUpdateEmployeeEventHandler(IEmployeeTransferRepository enployeeTransferRepository)
        {
            _enployeeTransferRepository = enployeeTransferRepository;
        }
        public Task Handle(UpdateEmployeeEvent @event)
        {
            _enployeeTransferRepository.TransferUpdateEmployee(@event.Id, new Employee()
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
