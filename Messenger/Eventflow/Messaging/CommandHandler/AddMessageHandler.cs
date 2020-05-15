using System.Threading;
using System.Threading.Tasks;
using EventFlow.Commands;
using Messenger.Eventflow.Messaging.Commands;

namespace Messenger.Eventflow.Messaging.CommandHandler
{
    public class AddMessageHandler : CommandHandler<MessagingAggregate, ConversationId, AddMessage>
    {
        public override Task ExecuteAsync(MessagingAggregate aggregate, AddMessage command, CancellationToken cancellationToken)
        {
            aggregate.AddMessage(command.Message);
            return Task.CompletedTask;
        }
    }
}
