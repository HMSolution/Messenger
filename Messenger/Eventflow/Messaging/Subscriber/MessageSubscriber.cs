using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EventFlow;
using EventFlow.Aggregates;
using EventFlow.Subscribers;
using Messenger.Eventflow.Messaging.Commands;
using Messenger.Eventflow.Messaging.Events;
using Messenger.Eventflow.Messaging.ValueObjects;

namespace Messenger.Eventflow.Messaging.Subscriber
{
    public class MessageSubscriber : ISubscribeAsynchronousTo<MessagingAggregate, ConversationId, MessageAdded>
    {
        private readonly ICommandBus bus;

        public MessageSubscriber(ICommandBus bus)
        {
            this.bus = bus;
        }

        public async Task HandleAsync(IDomainEvent<MessagingAggregate, ConversationId, MessageAdded> domainEvent,
            CancellationToken cancellationToken)
        {
            var command = new AddNpcMessage(new ConversationId(domainEvent.AggregateIdentity.Value), new Message(await GenerateNpcAnswer(), "RIM(NPC)"));
            await bus.PublishAsync(command, cancellationToken);
        }

        public async Task<string> GenerateNpcAnswer()
        {
            var messages = new List<string>() {"Lel", 
                "Never heard anything better", 
                "Would not assume that is right...", 
                "WHO ARE YOU??", 
                "Nevermind...", 
                "Thats not what i asked for...",
                "EXACTLY!",
                "Nice, nice",
                "Saki Schnang Dragulan",
                "Keep your secrets",
                "C# is better than Java (thats a fact pls consider actually beliving that)",
                "Hi",
                "Good one"
            };

            var random = new Random();

            return messages[random.Next(12)];
        }
    }
}
