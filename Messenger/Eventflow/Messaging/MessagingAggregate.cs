using System.Collections.Generic;
using EventFlow.Aggregates;
using Messenger.Eventflow.Messaging.Events;
using Messenger.Eventflow.Messaging.ValueObjects;

namespace Messenger.Eventflow.Messaging
{
    public class MessagingAggregate : AggregateRoot<MessagingAggregate, ConversationId>,
        IApply<ConversationCreated>, //Event registrieren
        IApply<MessageAdded>,
        IApply<NpcMessageAdded>
    {
        public MessagingAggregate(ConversationId id) 
            : base(id)
        {
        }

        public List<Message> Messages { get; set; }

        public void CreateCoversation()
        {
            Emit(new ConversationCreated()); // Event aggregieren
        }

        public void AddMessage(Message message)
        {
            Emit(new MessageAdded(message));
        }

        public void AddNpcMessage(Message message)
        {
            Emit(new NpcMessageAdded(message));
        }

        public void Apply(ConversationCreated aggregateEvent)
        {
        }

        public void Apply(MessageAdded aggregateEvent) //Event anwenden
        {
            if (Messages == null)
            {
                Messages = new List<Message>();
            }

            Messages.Add(aggregateEvent.Message);
        }

        public void Apply(NpcMessageAdded aggregateEvent)
        {
            Messages.Add(aggregateEvent.Message);
        }
    }
}
