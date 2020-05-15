using EventFlow.Commands;

namespace Messenger.Eventflow.Messaging.Commands
{
    public class AddMessage : Command<MessagingAggregate, UnterhaltungId>
    {
        public string Message { get; set; }

        public AddMessage(UnterhaltungId aggregateId, string message) : base(aggregateId)
        {
            Message = message;
        }
    }
}
