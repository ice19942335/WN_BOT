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
                // Database context
                TelegramContext telegramContext = serviceScope.ServiceProvider.GetRequiredService<TelegramContext>();
                await telegramContext.Database.MigrateAsync();

                // SQL Server default data initialization
                SQLDataInitializer contextInitializer = new SQLDataInitializer(telegramContext);
                await contextInitializer.InitializeAsync();
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
