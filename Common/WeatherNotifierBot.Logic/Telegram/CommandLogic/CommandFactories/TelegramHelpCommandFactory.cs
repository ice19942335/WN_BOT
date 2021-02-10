using System.Threading;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using WeatherNotifierBot.Logic.Telegram.CommandLogic.Command;
using WeatherNotifierBot.Logic.Telegram.CommandLogic.CommandAbstraction;

namespace WeatherNotifierBot.Logic.Telegram.CommandLogic.CommandFactories
{
    public class TelegramHelpCommandFactory : TelegramCommandFactory
    {
        private readonly ITurnContext<IMessageActivity> _turnContext;
        private readonly CancellationToken _cancellationToken;

        public TelegramHelpCommandFactory(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            _turnContext = turnContext;
            _cancellationToken = cancellationToken;
        }

        public override ITelegramCommand FactoryMethod()
        {
            return new TelegramHelpCommand(_turnContext, _cancellationToken)
            {
                Name = nameof(TelegramHelpCommand)
            };
        }
    }
}
