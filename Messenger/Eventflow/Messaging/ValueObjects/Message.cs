using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventFlow.ValueObjects;

namespace Messenger.Eventflow.Messaging.ValueObjects
{
    public class Message : ValueObject
    {
        public string MessageString { get; }
        public string Sender { get; }

        public Message(string message, string sender)
        {
            MessageString = message;
            Sender = sender;
        }
    }
}
