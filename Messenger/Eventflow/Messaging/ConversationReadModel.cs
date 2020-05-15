using System.Collections.Generic;
using EventFlow.Aggregates;
using EventFlow.MongoDB.ReadStores;
using EventFlow.ReadStores;
using Messenger.Eventflow.Messaging.Events;

namespace Messenger.Eventflow.Messaging
{
    public class ConversationReadModel : IMongoDbReadModel, // The read model is a data projection from chosen events
        IAmReadModelFor<MessagingAggregate, UnterhaltungId, ConversationCreated>,
        IAmReadModelFor<MessagingAggregate, UnterhaltungId, MessageAdded> //Here you see the events that are registered to this read model
    {
        public string Id { get; set; }
        public long? Version { get; set; }
        public List<string> Messages { get; set; }

        public void Apply(IReadModelContext context, IDomainEvent<MessagingAggregate, UnterhaltungId, ConversationCreated> domainEvent)
        {
            Id = domainEvent.AggregateIdentity.Value;
        }

        public void Apply(IReadModelContext context, IDomainEvent<MessagingAggregate, UnterhaltungId, MessageAdded> domainEvent) //Here you see the application of an event to a read model which is updating its information. After this the old read model in the MongoDb is replaced by the new one
        {
            if (Messages == null)
            {
                Messages = new List<string>();
            }

            Messages.Add(domainEvent.AggregateEvent.Message);
        }
    }
}
