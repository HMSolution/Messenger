﻿using EventFlow.Aggregates;
using Messenger.Eventflow.Messaging.ValueObjects;

namespace Messenger.Eventflow.Messaging.Events
{
    public class MessageAdded : AggregateEvent<MessagingAggregate, ConversationId>
    {
        public Message Message { get; set; }

        public MessageAdded(Message message) //Event contains the required data again, for the read model and aggregate to apply 
        {
            Message = message;
        }
    }
}
