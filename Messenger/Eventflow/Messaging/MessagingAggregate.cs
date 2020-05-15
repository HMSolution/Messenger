using System.Collections.Generic;
using EventFlow.Aggregates;
using Messenger.Eventflow.Messaging.Events;

namespace Messenger.Eventflow.Messaging
{
    public class MessagingAggregate : AggregateRoot<MessagingAggregate, UnterhaltungId>,
        IApply<ConversationCreated>, //Event registrieren
        IApply<MessageAdded>
    {
        public MessagingAggregate(UnterhaltungId id) 
            : base(id)
        {
        }

        public List<string> Messages { get; set; }

        public void CreateCoversation()
        {
            Emit(new ConversationCreated()); // Event aggregieren
        }

        public void AddMessage(string message)
        {
            Emit(new MessageAdded(message));
        }

        public void Apply(ConversationCreated aggregateEvent)
        {
        }

        public void Apply(MessageAdded aggregateEvent) //Event anwenden
        {
            if (Messages == null)
            {
                Messages = new List<string>();
            }

            Messages.Add(aggregateEvent.Message);
        }
    }
}
