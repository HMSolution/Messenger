using System.Collections.Generic;
using EventFlow.Aggregates;
using Messenger.Eventflow.Messaging.Events;

namespace Messenger.Eventflow.Messaging
{
    public class MessagingAggregate : AggregateRoot<MessagingAggregate, UnterhaltungId>,
        IApply<UnterhaltungErstellt>, //Event registrieren
        IApply<MessageHinzugefügt>
    {
        public MessagingAggregate(UnterhaltungId id) 
            : base(id)
        {
        }

        public List<string> Messages { get; set; }

        public void UnterhaltungErstellen()
        {
            Emit(new UnterhaltungErstellt()); // Event aggregieren
        }

        public void MessageHinzufügen(string message)
        {
            Emit(new MessageHinzugefügt(message));
        }

        public void Apply(UnterhaltungErstellt aggregateEvent)
        {
        }

        public void Apply(MessageHinzugefügt aggregateEvent) //Event anwenden
        {
            if (Messages == null)
            {
                Messages = new List<string>();
            }

            Messages.Add(aggregateEvent.Message);
        }
    }
}
