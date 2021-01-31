using System.Threading.Tasks;

namespace WeatherNotifierBot.Logic.Telegram.CommandAbstraction
{
    public interface ITelegramCommand
    {
        string Name { get; set; }

        Task GenerateResponse();
    }
}
