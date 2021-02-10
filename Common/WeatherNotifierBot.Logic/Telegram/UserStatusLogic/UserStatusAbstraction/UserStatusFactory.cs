using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeatherNotifierBot.Logic.Telegram.UserStatusLogic.UserStatusAbstraction
{
    public abstract class UserStatusFactory
    {
        public abstract IUserStatusFactory FactoryMethod();
    }

    public interface IUserStatusFactory
    {
        string Name { get; set; }

        Task SomeLogic();
    }

    public abstract class UserStatusEnterCityNameFactory : UserStatusFactory
    {
        public override IUserStatusFactory FactoryMethod()
        {
            return new UserStatusEnterCityName();
        }
    }

    public class UserStatusEnterCityName : IUserStatusFactory
    {
        public string Name { get; set; }

        public Task SomeLogic()
        {
            throw new NotImplementedException();
        }
    }
}
