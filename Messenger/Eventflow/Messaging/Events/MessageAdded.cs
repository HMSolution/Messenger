using EventFlow.Aggregates;

namespace Messenger.Eventflow.Messaging.Events
{
    public class MessageAdded : AggregateEvent<MessagingAggregate, UnterhaltungId>
    {
        public string Message { get; set; }

        public MessageAdded(string message) //Event contains the required data again, for the read model and aggregate to apply 
        {
            Message = message;
        }
    }
}
