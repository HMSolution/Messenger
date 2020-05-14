
using System.Threading;
using System.Threading.Tasks;
using EventFlow.Commands;
using Messenger.Eventflow.Messaging.Commands;

namespace Messenger.Eventflow.Messaging.CommandHandler
{
    public class MessageHinzufügenHandler : CommandHandler<MessagingAggregate, UnterhaltungId, MessageHinzufügen>
    {
        public override Task ExecuteAsync(MessagingAggregate aggregate, MessageHinzufügen command, CancellationToken cancellationToken)
        {
            aggregate.MessageHinzufügen(command.Message);
            return Task.CompletedTask;
        }
    }
}
