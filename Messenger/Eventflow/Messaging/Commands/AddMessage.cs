﻿using EventFlow.Commands;
using Messenger.Eventflow.Messaging.ValueObjects;

namespace Messenger.Eventflow.Messaging.Commands
{
    public class AddMessage : Command<MessagingAggregate, ConversationId>
    {
        public Message Message { get; set; }

        public AddMessage(ConversationId aggregateId, Message message) : base(aggregateId)
        {
            Message = message;
        }
    }
}
