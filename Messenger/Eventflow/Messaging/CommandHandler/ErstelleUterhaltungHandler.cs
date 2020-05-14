using System.Threading;
using System.Threading.Tasks;
using EventFlow.Commands;
using Messenger.Eventflow.Messaging.Commands;

namespace Messenger.Eventflow.Messaging.CommandHandler
{
    public class ErstelleUterhaltungHandler : CommandHandler<MessagingAggregate, UnterhaltungId, ErstelleUnterhaltung>
    {
        public override Task ExecuteAsync(MessagingAggregate aggregate, ErstelleUnterhaltung command, CancellationToken cancellationToken)
        {
            aggregate.UnterhaltungErstellen(); // Aggregat ansprechen, mit den Daten aus dem Command
            return Task.CompletedTask;
        }
    }
}
