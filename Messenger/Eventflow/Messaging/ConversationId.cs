using EventFlow.Core;

namespace Messenger.Eventflow.Messaging
{
    public class ConversationId : Identity<ConversationId> //AggregateIdentity over this events are emitted and read models queried
    {
        public ConversationId(string value) : base(value)
        {
        }
    }
}
