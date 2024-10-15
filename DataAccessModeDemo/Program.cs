using DataAccessModeDemo.AdoNet;
using DataAccessModeDemo.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessModeDemo
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IConfiguration connfiguration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton(connfiguration);
            serviceCollection.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
            serviceCollection.AddScoped<IOrderService, SqlKataOrderService>();
            serviceCollection.AddTransient<MainForm>();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var mainForm = serviceProvider.GetService<MainForm>();
            Application.Run(mainForm);
        }
    }
}