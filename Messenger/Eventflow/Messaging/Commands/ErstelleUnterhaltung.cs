using EventFlow.Commands;

namespace Messenger.Eventflow.Messaging.Commands
{
    public class ErstelleUnterhaltung : Command<MessagingAggregate, UnterhaltungId>
    {
        public ErstelleUnterhaltung(UnterhaltungId id)
            : base(id)
        {
        }
    }
}
