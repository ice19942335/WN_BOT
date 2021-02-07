using Hangfire;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherNotifierBot.Domain.Cron;
using WeatherNotifierBot.Logic.Servcies.Interfaces;

namespace WeatherNotifierBot.Logic.Servcies
{
    public class HangFireJobInitializer : IHangFireJobInitializer
    {
        private readonly INotificationLogic _notificationLogic;

        public HangFireJobInitializer(INotificationLogic notificationLogic)
        {
            _notificationLogic = notificationLogic;
        }

        public void InitializeAsync()
        {
            RecurringJob.AddOrUpdate(() => _notificationLogic.HorlyNotification(), CronExpressions.EveryMinute);
        }
    }
}
