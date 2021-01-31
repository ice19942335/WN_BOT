using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System.Threading;
using System.Threading.Tasks;
using WeatherNotifierBot.Logic.Telegram.CommandAbstraction;

namespace WeatherNotifierBot.Logic.Telegram.Command
{
    public class TelegramSetCityCommand : ITelegramCommand
    {
        private readonly ITurnContext<IMessageActivity> _turnContext;
        private readonly CancellationToken _cancellationToken;

        public TelegramSetCityCommand(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            _turnContext = turnContext;
            _cancellationToken = cancellationToken;
        }

        public string Name { get; set; }

        public async Task GenerateResponse()
        {
            await _turnContext.SendActivityAsync(MessageFactory.Text("This is a /SetCity command"), _cancellationToken);
        }
    }
}
