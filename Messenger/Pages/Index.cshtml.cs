using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EventFlow;
using EventFlow.Queries;
using Messenger.Eventflow.Messaging;
using Messenger.Eventflow.Messaging.Commands;
using Messenger.Eventflow.Messaging.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Messenger.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public ICommandBus CommandBus { get; }
        public IQueryProcessor QueryProcessor { get; }
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public string Id { get; set; }

        public List<Message> Messages { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ICommandBus commandBus, IQueryProcessor queryProcessor)
        {
            _logger = logger;
            CommandBus = commandBus;
            QueryProcessor = queryProcessor;
        }

        public async Task OnGet()
        {

            if (this.UserName == null)
            {
                this.UserName = GetString("UserName");
                if (this.UserName == null)
                {
                    this.UserName = "ShyGuy";
                }
            }

            ConversationId identity;
            var test = GetString("identity"); //get identity from current conversation in session
            if (test == null)
            {
                identity = ConversationId.New;
                SetString("identity", identity.ToString()); // save identity to session
                var command = new CreateConversation(identity);
                await CommandBus.PublishAsync(command, CancellationToken.None); //transferring command to its handler
            }
            else
            {
                identity = new ConversationId(test);
            }

            var result = await QueryProcessor.ProcessAsync(new ReadModelByIdQuery<ConversationReadModel>(identity),
                CancellationToken.None); // ReadModelByIDQuery is out of the box in Event Flow for quering read models

            if (result.Messages == null)
            {
                Messages = new List<Message>();
            }
            else
            {
                Messages = result.Messages;
            }
        }

        public async Task<IActionResult> OnPost()
        {
            SetString("UserName", UserName);
            var identity = new ConversationId(GetString("identity"));
            var command = new AddMessage(identity, new Message(Message, UserName));
            await CommandBus.PublishAsync(command, CancellationToken.None);

            return this.RedirectToPage("Index");
        }

        public string GetString(string key)
        {
            return HttpContext.Session.GetString(key);
        }

        public void SetString(string key, string value)
        {
            HttpContext.Session.SetString(key, value);
        }
    }
}
