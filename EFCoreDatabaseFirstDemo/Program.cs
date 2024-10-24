// See https://aka.ms/new-console-template for more information
using EFCoreDatabaseFirstDemo.Data;
using EFCoreDatabaseFirstDemo.Models;



var dbContex = new NorthwindDbConext();
var category = new Category();
category.CategoryName = "Test";
dbContex.Categories.Add(category);
dbContex.SaveChanges();