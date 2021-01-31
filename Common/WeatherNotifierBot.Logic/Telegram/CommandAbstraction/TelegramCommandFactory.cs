namespace WeatherNotifierBot.Logic.Telegram.CommandAbstraction
{
    public abstract class TelegramCommandFactory
    {
        public abstract ITelegramCommand FactoryMethod();
    }
}
