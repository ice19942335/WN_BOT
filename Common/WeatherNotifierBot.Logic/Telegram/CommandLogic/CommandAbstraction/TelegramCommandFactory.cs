namespace WeatherNotifierBot.Logic.Telegram.CommandLogic.CommandAbstraction
{
    public abstract class TelegramCommandFactory
    {
        public abstract ITelegramCommand FactoryMethod();
    }
}
