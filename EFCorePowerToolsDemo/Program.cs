
using EFCorePowerToolsDemo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();
serviceCollection.AddDbContext<NorthwindDbContext>(options =>
{
    options.UseSqlServer("Server=(localdb)\\MSSQLLocalDb;Database=Northwind");
});


var serviceProvider = serviceCollection.BuildServiceProvider();

var dbContext = serviceProvider.GetRequiredService<NorthwindDbContext>();


var products = dbContext.Products.ToList();


foreach (var product in products)
{
    Console.WriteLine($"{product.ProductName} {product.UnitPrice}");
}
