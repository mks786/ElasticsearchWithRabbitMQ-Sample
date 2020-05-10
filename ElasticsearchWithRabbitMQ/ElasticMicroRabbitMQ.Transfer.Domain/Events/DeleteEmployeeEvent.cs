using ElasticMicroRabbitMQ.Domain.Core.Events;

namespace ElasticMicroRabbitMQ.Transfer.Domain.Events
{
    public class DeleteEmployeeEvent : Event
    {
        public int Id { get; private set; }

        public DeleteEmployeeEvent(int id)
        {
            Id = id;
        }
    }
}
