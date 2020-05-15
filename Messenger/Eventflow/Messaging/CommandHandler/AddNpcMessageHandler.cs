using System.Threading;
using System.Threading.Tasks;
using EventFlow.Commands;
using Messenger.Eventflow.Messaging.Commands;

namespace Messenger.Eventflow.Messaging.CommandHandler
{
    public class AddNpcMessageHandler : CommandHandler<MessagingAggregate, ConversationId, AddNpcMessage>
    {
        public override Task ExecuteAsync(MessagingAggregate aggregate, AddNpcMessage command, CancellationToken cancellationToken)
        {
            aggregate.AddNpcMessage(command.Message);
            return Task.CompletedTask;
        }
    }
}
