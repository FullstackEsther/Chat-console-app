// See https://aka.ms/new-console-template for more information
using MyProject.Context;
using MyProject.Menu;

// Console.WriteLine("Hello, World!");
FileContext fileContext = new FileContext();
fileContext.Create();
MainMenu men = new MainMenu();
men.UserMenu();
