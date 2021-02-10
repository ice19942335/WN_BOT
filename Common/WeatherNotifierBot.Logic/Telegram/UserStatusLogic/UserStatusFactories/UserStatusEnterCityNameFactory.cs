using WeatherNotifierBot.Logic.Telegram.UserStatusLogic.UserStatus;
using WeatherNotifierBot.Logic.Telegram.UserStatusLogic.UserStatusAbstraction;

namespace WeatherNotifierBot.Logic.Telegram.UserStatusLogic.UserStatusFactories
{
    public abstract class UserStatusEnterCityNameFactory : UserStatusFactory
    {
        public override IUserStatusFactory FactoryMethod()
        {
            return new UserStatusEnterCityName();
        }
    }
}