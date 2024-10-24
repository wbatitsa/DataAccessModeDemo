using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6DataAccessDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new NorthwindEntities();

            // Create
            var newProduct = new Product() { };
            context.Products.Add(newProduct);
            context.SaveChanges();

            // Read All
            var allProducts = context.Products.ToList();

            // Read by
            var filteredProducts = context.Products.Where(a=> a.ProductName == "Banana").ToList();

            // Read by Id
            var productById = context.Products.Where(a => a.ProductID == 1).First();

            // Update
            var updateProduct = context.Products.Find(1);
            updateProduct.ProductName = "Test";
            context.SaveChanges();

            // Delete
            var deleteProduct = context.Products.Find(1);
            context.Products.Remove(deleteProduct);
            context.SaveChanges();
        }
    }
}
