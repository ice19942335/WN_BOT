using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System.Threading;
using WeatherNotifierBot.Logic.Telegram.Command;
using WeatherNotifierBot.Logic.Telegram.CommandAbstraction;

namespace WeatherNotifierBot.Logic.Telegram.CommandFactories
{

    public class TelegramSetCityCommandFactory : TelegramCommandFactory
    {
        private readonly ITurnContext<IMessageActivity> _turnContext;
        private readonly CancellationToken _cancellationToken;

        public TelegramSetCityCommandFactory(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            _turnContext = turnContext;
            _cancellationToken = cancellationToken;
        }

        public override ITelegramCommand FactoryMethod()
        {
            return new TelegramSetCityCommand(_turnContext, _cancellationToken)
            {
                Name = nameof(TelegramSetCityCommand)
            };
        }
    }
}
