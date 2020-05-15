using EventFlow.Commands;
using Messenger.Eventflow.Messaging.ValueObjects;

namespace Messenger.Eventflow.Messaging.Commands
{
    public class AddNpcMessage : Command<MessagingAggregate, ConversationId>
    {
        public Message Message { get; set; }

        public AddNpcMessage(ConversationId aggregateId, Message message) : base(aggregateId)
        {
            Message = message;
        }
    }
}
