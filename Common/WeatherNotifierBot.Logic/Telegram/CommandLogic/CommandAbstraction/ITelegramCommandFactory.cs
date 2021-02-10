using System.Threading.Tasks;

namespace WeatherNotifierBot.Logic.Telegram.CommandLogic.CommandAbstraction
{
    public interface ITelegramCommandFactory
    {
        string Name { get; set; }

        Task GenerateResponse();
    }
}
