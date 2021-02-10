using System.Threading;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using WeatherNotifierBot.Logic.Telegram.CommandLogic.Command;
using WeatherNotifierBot.Logic.Telegram.CommandLogic.CommandAbstraction;

namespace WeatherNotifierBot.Logic.Telegram.CommandLogic.CommandFactories
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

        public override ITelegramCommandFactory FactoryMethod()
        {
            return new Command.TelegramSetCityCommandFactory(_turnContext, _cancellationToken)
            {
                Name = nameof(Command.TelegramSetCityCommandFactory)
            };
        }
    }
}
