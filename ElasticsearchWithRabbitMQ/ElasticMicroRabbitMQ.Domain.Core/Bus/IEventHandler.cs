using ElasticMicroRabbitMQ.Domain.Core.Events;
using System.Threading.Tasks;

namespace ElasticMicroRabbitMQ.Domain.Core.Bus
{
    public interface IEventHandler<in TEvent> : IEventHandler
    where TEvent : Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {

    }
}
