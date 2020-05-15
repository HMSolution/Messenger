using EventFlow.Aggregates;
using Messenger.Eventflow.Messaging;

namespace Messenger.Eventflow.Messaging.Events
{
    public class ConversationCreated : AggregateEvent<MessagingAggregate, ConversationId>
    {
        public ConversationCreated()
        {
        }
    }
}
