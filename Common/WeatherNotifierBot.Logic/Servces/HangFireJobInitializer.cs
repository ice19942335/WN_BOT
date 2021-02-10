using Hangfire;
using WeatherNotifierBot.Domain.Cron;
using WeatherNotifierBot.Logic.Servces.Interfaces;

namespace WeatherNotifierBot.Logic.Servces
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
