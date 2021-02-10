using System;
using WeatherNotifierBot.Logic.Services.Interfaces;

namespace WeatherNotifierBot.Logic.Services
{
    public class NotificationLogic : INotificationLogic
    {
        public NotificationLogic()
        {

        }

        public void HorlyNotification()
        {
            Console.WriteLine("Easy!", Environment.NewLine);
        }
    }
}
