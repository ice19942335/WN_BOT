using System;
using WeatherNotifierBot.Logic.Servces.Interfaces;

namespace WeatherNotifierBot.Logic.Servces
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
