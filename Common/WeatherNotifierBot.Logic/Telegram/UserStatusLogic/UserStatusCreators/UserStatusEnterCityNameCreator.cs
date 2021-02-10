using WeatherNotifierBot.Logic.Telegram.UserStatusLogic.UserStatus;
using WeatherNotifierBot.Logic.Telegram.UserStatusLogic.UserStatusAbstraction;

namespace WeatherNotifierBot.Logic.Telegram.UserStatusLogic.UserStatusCreators
{
    public class UserStatusEnterCityNameCreator : UserStatusFactory
    {
        public override IUserStatusFactory FactoryMethod()
        {
            return new UserStatusEnterCityName();
        }
    }
}