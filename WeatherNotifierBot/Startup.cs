// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.BotBuilderSamples.Bots;
using Microsoft.Extensions.Hosting;
using EasyShop.DAL.Context;
using Microsoft.EntityFrameworkCore;
using WeatherNotifierBot.Logic.Servcies.Interfaces;
using WeatherNotifierBot.Logic.Servcies;
using Hangfire;
using WeatherNotifierBot.Domain.Cron;

namespace Microsoft.BotBuilderSamples
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();

            // Telegram DB context
            services.AddDbContext<TelegramContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));

            // Hangfire
            services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("DevConnection")));
            services.AddHangfireServer();

            // Servcies
            services.AddScoped<IUserLogic, UserLogic>();
            services.AddScoped<INotificationLogic, NotificationLogic>();
            services.AddScoped<IWeatherLogic, WeatherLogic>();
            services.AddScoped<IHangFireJobInitializer, HangFireJobInitializer>();

            // Create the Bot Framework Adapter with error handling enabled.
            services.AddSingleton<IBotFrameworkHttpAdapter, AdapterWithErrorHandler>();

            // Create the bot as a transient. In this case the ASP Controller is expecting an IBot.
            services.AddTransient<IBot, TelegramBot>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Hangfire dashboard
                app.UseHangfireDashboard();

            }

            // Hangfire server
            app.UseHangfireServer();
            RecurringJob.AddOrUpdate<INotificationLogic>(x => x.HorlyNotification(), CronExpressions.EveryMinute);

            app.UseDefaultFiles()
                .UseStaticFiles()
                .UseWebSockets()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

            app.UseHttpsRedirection();
        }
    }
}
