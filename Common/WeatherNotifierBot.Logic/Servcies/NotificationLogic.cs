using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherNotifierBot.Logic.Servcies.Interfaces;

namespace WeatherNotifierBot.Logic.Servcies
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
