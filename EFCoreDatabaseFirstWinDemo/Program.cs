using EFCoreDatabaseFirstWinDemo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreDatabaseFirstWinDemo
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<NorthwindDbConext>(options =>
            {
                options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind");
            });
            serviceCollection.AddTransient<OrderForm>();
            serviceCollection.AddTransient<MainForm>();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            ApplicationConfiguration.Initialize();

            var mainForm = serviceProvider.GetRequiredService<OrderForm>();
            Application.Run(mainForm);
        }
    }
}