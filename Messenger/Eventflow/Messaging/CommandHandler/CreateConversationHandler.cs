using System.Threading;
using System.Threading.Tasks;
using EventFlow.Commands;
using Messenger.Eventflow.Messaging.Commands;

namespace Messenger.Eventflow.Messaging.CommandHandler
{
    public class CreateConversationHandler : CommandHandler<MessagingAggregate, ConversationId, CreateConversation>
    {
        public override Task ExecuteAsync(MessagingAggregate aggregate, CreateConversation command, CancellationToken cancellationToken)
        {
            aggregate.CreateCoversation(); //Calling aggregate method with the information from the command (in this case there is none)
            return Task.CompletedTask;
        }
    }
}
