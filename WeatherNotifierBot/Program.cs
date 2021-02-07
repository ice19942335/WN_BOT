using EasyShop.DAL.Context;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WeatherNotifierBot.Logic.Servcies.Initialization;
using WeatherNotifierBot.Logic.Servcies.Interfaces;

namespace Microsoft.BotBuilderSamples
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                IConfiguration congiration = serviceScope.ServiceProvider.GetRequiredService<IConfiguration>();

                // Hangfire
                var sqlStorage = new SqlServerStorage(congiration.GetConnectionString("DevConnection"));
                var options = new BackgroundJobServerOptions { ServerName = "WNBotServer" };
                JobStorage.Current = sqlStorage;

                TelegramContext telegramContext = serviceScope.ServiceProvider.GetRequiredService<TelegramContext>();
                await telegramContext.Database.MigrateAsync();

                MSSQLInitializer contextInitializer = new MSSQLInitializer(telegramContext);
                await contextInitializer.InitializeAsync();

                INotificationLogic notificationLogic = serviceScope.ServiceProvider.GetRequiredService<INotificationLogic>();
                RecurringJob.AddOrUpdate(() => Console.WriteLine("Hello"), "*/1 * * * *");
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureLogging((logging) =>
                    {
                        logging.AddDebug();
                        logging.AddConsole();
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
