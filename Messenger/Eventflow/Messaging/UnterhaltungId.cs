using EventFlow.Core;

namespace Messenger.Eventflow.Messaging
{
    public class UnterhaltungId : Identity<UnterhaltungId> //AggregateIdentity over this events are emitted and read models queried
    {
        public UnterhaltungId(string value) : base(value)
        {
        }
    }
}
