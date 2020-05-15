using EventFlow.Commands;

namespace Messenger.Eventflow.Messaging.Commands
{
    public class CreateConversation : Command<MessagingAggregate, ConversationId>
    {
        public CreateConversation(ConversationId id) //The command itself serves as a data container, even an empty one would contain a specific action
            : base(id)
        {
        }
    }
}
