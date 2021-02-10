using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using WeatherNotifierBot.Logic.Telegram.CommandLogic.CommandAbstraction;

namespace WeatherNotifierBot.Logic.Telegram.CommandLogic.Command
{
    public class TelegramHelpCommandFactory : ITelegramCommandFactory
    {
        private readonly ITurnContext<IMessageActivity> _turnContext;
        private readonly CancellationToken _cancellationToken;

        public TelegramHelpCommandFactory(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            _turnContext = turnContext;
            _cancellationToken = cancellationToken;
        }

        public string Name { get; set; }

        public async Task GenerateResponse()
        {
            await _turnContext.SendActivityAsync(MessageFactory.Text("This is a /Help command"), _cancellationToken);
        }
    }
}
