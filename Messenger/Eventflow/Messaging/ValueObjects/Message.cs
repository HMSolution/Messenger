using EventFlow.ValueObjects;
using Newtonsoft.Json;

namespace Messenger.Eventflow.Messaging.ValueObjects
{
    public class Message : ValueObject
    {
        public string MessageString { get; set; }
        public string Sender { get; set; }

        public Message(string message, string sender)
        {
            MessageString = message;
            Sender = sender;
        }
    }
}
