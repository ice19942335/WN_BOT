using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WeatherNotifierBot.DAL.Context;
using WeatherNotifierBot.Logic.Services.Initialization;

namespace WeatherNotifierBot
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
                SqlDataInitializer contextInitializer = new SqlDataInitializer(telegramContext);
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
