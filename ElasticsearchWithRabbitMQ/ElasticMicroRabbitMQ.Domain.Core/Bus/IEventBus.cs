using ElasticMicroRabbitMQ.Domain.Core.Commands;
using ElasticMicroRabbitMQ.Domain.Core.Events;
using System.Threading.Tasks;

namespace ElasticMicroRabbitMQ.Domain.Core.Bus
{
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : Command;

        void Publish<T>(T @event) where T : Event;

        void Subscriber<T, TH>()
            where T : Event
            where TH : IEventHandler<T>;
    }
}
