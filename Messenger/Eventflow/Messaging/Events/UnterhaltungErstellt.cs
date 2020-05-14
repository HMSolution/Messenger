using EventFlow.Aggregates;
using Messenger.Eventflow.Messaging;

namespace Messenger.Eventflow.Messaging.Events
{
    public class UnterhaltungErstellt : AggregateEvent<MessagingAggregate, UnterhaltungId>
    {
        public UnterhaltungErstellt()
        {
        }
    }
}
