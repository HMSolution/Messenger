using EventFlow.Commands;

namespace Messenger.Eventflow.Messaging.Commands
{
    public class MessageHinzufügen : Command<MessagingAggregate, UnterhaltungId>
    {
        public string Message { get; set; }

        public MessageHinzufügen(UnterhaltungId aggregateId, string message) : base(aggregateId)
        {
            Message = message;
        }
    }
}
