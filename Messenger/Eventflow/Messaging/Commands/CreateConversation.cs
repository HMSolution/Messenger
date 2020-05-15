using EventFlow.Commands;

namespace Messenger.Eventflow.Messaging.Commands
{
    public class CreateConversation : Command<MessagingAggregate, UnterhaltungId>
    {
        public CreateConversation(UnterhaltungId id) //The command itself serves as a data container, even an empty one would contain a specific action
            : base(id)
        {
        }
    }
}
