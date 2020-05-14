using EventFlow.Aggregates;

namespace Messenger.Eventflow.Messaging.Events
{
    public class MessageHinzugefügt : AggregateEvent<MessagingAggregate, UnterhaltungId>
    {
        public string Message { get; set; }

        public MessageHinzugefügt(string message) //Event enthält die notwendigen Daten für das Aggregat und das ReadModel
        {
            Message = message;
        }
    }
}
