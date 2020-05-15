using EventFlow.Aggregates;
using Messenger.Eventflow.Messaging.ValueObjects;

namespace Messenger.Eventflow.Messaging.Events
{
    public class NpcMessageAdded : AggregateEvent<MessagingAggregate, ConversationId>
    {
        public Message Message { get; set; }

        public NpcMessageAdded(Message message)
        {
            Message = message;
        }
    }
}
