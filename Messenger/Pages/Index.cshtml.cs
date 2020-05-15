using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EventFlow;
using EventFlow.Queries;
using Messenger.Eventflow;
using Messenger.Eventflow.Messaging;
using Messenger.Eventflow.Messaging.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Messenger.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public ICommandBus CommandBus { get; set; }
        public IQueryProcessor QueryProcessor { get; set; }

        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public string Id { get; set; }

        public List<string> Messages { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ICommandBus commandBus, IQueryProcessor queryProcessor)
        {
            _logger = logger;
            CommandBus = commandBus;
            QueryProcessor = queryProcessor;
        }

        public async Task OnGet()
        {
            UnterhaltungId identity;
            var test = GetString("identity"); //identity aus der Session holen
            if (test == null)
            {
                identity = UnterhaltungId.New;
                HttpContext.Session.SetString("identity", identity.ToString()); // identity in der Session speichern
                var command = new CreateConversation(identity);
                await CommandBus.PublishAsync(command, CancellationToken.None); //Command an Handler transferieren => siehe CommandHandler
            }
            else
            {
                identity = new UnterhaltungId(test);
            }

            var result = await QueryProcessor.ProcessAsync(new ReadModelByIdQuery<ConversationReadModel>(identity),
                CancellationToken.None); // ReadModelByIDQuery wird von EventFlow out of the Box geliefert, um ReadModel zu querien

            if (result.Messages == null)
            {
                Messages = new List<string>();
            }
            else
            {
                Messages = result.Messages;
            }
        }

        public async Task<IActionResult> OnPost()
        {
            var identity = new UnterhaltungId(GetString("identity"));
            var command = new AddMessage(identity, Message);
            await CommandBus.PublishAsync(command, CancellationToken.None);

            return this.RedirectToPage("Index");
        }

        public string GetString(string key)
        {
            return HttpContext.Session.GetString(key);
        }
    }
}
