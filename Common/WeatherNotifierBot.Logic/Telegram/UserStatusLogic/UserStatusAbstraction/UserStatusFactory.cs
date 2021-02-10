using System.Collections.Generic;
using System.Text;

namespace WeatherNotifierBot.Logic.Telegram.UserStatusLogic.UserStatusAbstraction
{
    public abstract class UserStatusFactory
    {
        public abstract IUserStatusFactory FactoryMethod();
    }
}
