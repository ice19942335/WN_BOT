using System.Threading.Tasks;

namespace WeatherNotifierBot.Logic.Telegram.CommandLogic.CommandAbstraction
{
    public interface ITelegramCommand
    {
        string Name { get; set; }

        Task GenerateResponse();
    }
}
