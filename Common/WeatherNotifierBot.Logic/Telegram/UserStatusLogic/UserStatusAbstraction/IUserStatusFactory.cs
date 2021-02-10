using System.Threading.Tasks;

namespace WeatherNotifierBot.Logic.Telegram.UserStatusLogic.UserStatusAbstraction
{
    public interface IUserStatusFactory
    {
        string Name { get; set; }

        Task SomeLogic();
    }
}