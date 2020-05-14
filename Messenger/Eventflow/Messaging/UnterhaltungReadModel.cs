using System.Collections.Generic;
using EventFlow.Aggregates;
using EventFlow.MongoDB.ReadStores;
using EventFlow.ReadStores;
using Messenger.Eventflow.Messaging.Events;

namespace Messenger.Eventflow.Messaging
{
    public class UnterhaltungReadModel : IMongoDbReadModel, // Datenprojektion von ausgewählten Events
        IAmReadModelFor<MessagingAggregate, UnterhaltungId, UnterhaltungErstellt>,
        IAmReadModelFor<MessagingAggregate, UnterhaltungId, MessageHinzugefügt> //Registrieren eines Events
    {
        public string Id { get; set; }
        public long? Version { get; set; }
        public List<string> Messages { get; set; }

        public void Apply(IReadModelContext context, IDomainEvent<MessagingAggregate, UnterhaltungId, UnterhaltungErstellt> domainEvent)
        {
            Id = domainEvent.AggregateIdentity.Value;
        }

        public void Apply(IReadModelContext context, IDomainEvent<MessagingAggregate, UnterhaltungId, MessageHinzugefügt> domainEvent) //Anwenden eines Events, zum Übertragen der Daten in das Read Model
        {
            if (Messages == null)
            {
                Messages = new List<string>();
            }

            Messages.Add(domainEvent.AggregateEvent.Message);
        }
    }
}
