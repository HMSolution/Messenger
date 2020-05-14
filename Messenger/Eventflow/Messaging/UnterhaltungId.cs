using EventFlow.Core;

namespace Messenger.Eventflow.Messaging
{
    public class UnterhaltungId : Identity<UnterhaltungId> //Aggregatsidentität, über die Events laufen und ReadModel gequeriet werden
    {
        public UnterhaltungId(string value) : base(value)
        {
        }
    }
}
