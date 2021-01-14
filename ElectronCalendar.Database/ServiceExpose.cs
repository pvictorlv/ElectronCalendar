using System;
using ElectronCalendar.Database.Data;
using ElectronCalendar.Database.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ElectronCalendar.Database
{
    public static class ServiceExpose
    {
        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public static IServiceCollection AddDatabaseServices(this IServiceCollection serviceCollection,
            string dbConnectionString)
        {
            
            serviceCollection.AddDbContextPool<DatabaseContext>(builder =>
            {
                builder.EnableSensitiveDataLogging();
                var connBuilder = builder.UseSqlServer(dbConnectionString);
#if DEBUG

                connBuilder.UseLoggerFactory(MyLoggerFactory);
#endif
                connBuilder.ConfigureWarnings(w => w.Log(RelationalEventId.MultipleCollectionIncludeWarning));
            });


            serviceCollection.AddScoped<UserService>();

            return serviceCollection;
        }
    }
}